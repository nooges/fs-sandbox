#!/usr/bin/env -S dotnet fsi

type ColorFormat =
    | Rgb
    | Hsl
    | Hex

let parseIntArray =
    fun (s: string) -> s.Trim [| '('; ')' |]
    >> fun s -> s.Split ','
    >> Array.map int

let formatStrArray = String.concat "," >> sprintf "(%s)"

let rgbToHex =
    parseIntArray
    >> Array.map (sprintf "%02X")
    >> String.concat ""
    >> (+) "#"

let hexToRgb =
    fun (s: string) -> s.Trim [| '#' |]
    >> Seq.chunkBySize 2
    >> Seq.map ((fun s -> "0x" + new string (s)) >> int >> string)
    >> Seq.toArray
    >> formatStrArray

let rgbToHsl =
    parseIntArray
    >> Array.map (float >> (fun n -> n / 255.))
    >> (fun a ->
        let R = a[0]
        let G = a[1]
        let B = a[2]
        let M = Array.max a
        let m = Array.min a
        let C = M - m

        let H' =
            match M with
            | M when M = R -> (G - B) / C % 6.
            | M when M = G -> (B - R) / C + 2.
            | _ -> (R - G) / C + 4.

        let H = H' * 60.
        let L = (M + m) / 2.

        let S =
            if C = 0. then
                0.
            else
                C / (1. - abs (2. * L - 1.))

        [| round H
           round (100. * S)
           round (100. * L) |])
    >> Array.map string
    >> formatStrArray

let hslToRgb =
    parseIntArray
    >> Array.map float
    >> (fun a ->
        let H = a[0]
        let S = a[1] / 100.
        let L = a[2] / 100.
        let C = (1. - abs (2. * L - 1.)) * S
        let X = C * (1. - abs (H / 60. % 2. - 1.))
        let m = L - C / 2.

        match H with
        | H when H < 60 -> [| C; X; 0 |]
        | H when H < 120 -> [| X; C; 0 |]
        | H when H < 180 -> [| 0; C; X |]
        | H when H < 240 -> [| 0; X; C |]
        | H when H < 300 -> [| X; 0; C |]
        | _ -> [| C; 0; X |]
        |> Array.map (fun n -> round ((n + m) * 255.) |> string))
    >> formatStrArray

let hslToHex = hslToRgb >> rgbToHex
let hexToHsl = hexToRgb >> rgbToHsl

let convertColor inFormat outFormat =
    match (inFormat, outFormat) with
    | (Rgb, Hsl) -> rgbToHsl
    | (Rgb, Hex) -> rgbToHex
    | (Hsl, Rgb) -> hslToRgb
    | (Hsl, Hex) -> hslToHex
    | (Hex, Rgb) -> hexToRgb
    | (Hex, Hsl) -> hexToHsl
    | _ -> id

printfn "%A" <| convertColor Rgb Hex "(255,0,0)"
printfn "%A" <| rgbToHex "(255,0,0)"
printfn "%A" <| hexToRgb "#FFAA18"
printfn "%A" <| hexToHsl "#FFAA18"
printfn "%A" <| rgbToHsl "(0,128,0)"
printfn "%A" <| hslToRgb "(0,0,75)"
printfn "%A" <| (rgbToHsl "(0,128,0)" |> hslToRgb)
printfn "%A" <| convertColor Hsl Rgb "(65,80,80)"
printfn "%A" <| convertColor Hsl Hex "(65,80,80)"
