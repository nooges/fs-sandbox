#!/usr/bin/env -S dotnet fsi

let keyboardGrid =
    [| "qwertyuiop"
       "asdfghjkl;"
       "zxcvbnm,./" |]

let letterPosition letter =
    let row =
        keyboardGrid
        |> Array.findIndex (Seq.contains letter)

    let col =
        keyboardGrid.[row]
        |> Seq.findIndex (fun c -> c = letter)

    (row, col)

let moveInstructions (pos1, pos2) =
    let (r1, c1) = pos1
    let (r2, c2) = pos2

    let instructions1 =
        match c2 - c1 with
        | d when d > 0 -> List.replicate d "right"
        | d when d < 0 -> List.replicate -d "left"
        | _ -> []

    let instructions2 =
        match r2 - r1 with
        | d when d > 0 -> List.replicate d "down"
        | d when d < 0 -> List.replicate -d "up"
        | _ -> []

    instructions1 @ instructions2 @ [ "select" ]


let remoteControl str =
    "q" + str
    |> Seq.map letterPosition
    |> Seq.pairwise
    |> Seq.collect moveInstructions
    |> String.concat ", "

printfn "%A" <| remoteControl "car"
