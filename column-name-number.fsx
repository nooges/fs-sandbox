#!/usr/bin/env -S dotnet fsi

let columnNameNumber = Seq.fold (fun acc c -> acc * 26 + int c - 64) 0

printfn "%A" <| columnNameNumber "A"
printfn "%A" <| columnNameNumber "C"
printfn "%A" <| columnNameNumber "Z"
printfn "%A" <| columnNameNumber "AA"
printfn "%A" <| columnNameNumber "AB"
printfn "%A" <| columnNameNumber "AAA"
