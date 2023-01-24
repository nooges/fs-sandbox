#!/usr/bin/env -S dotnet fsi

let missingBits l =
    let expandPair (a, b) =
        match b - a with
        | 1 -> $"{a},"
        | 2 -> $"{a},{a + 1},"
        | _ -> $"{a},...,"

    let rec loop acc l =
        match l with
        | [ x ] -> $"{acc}{expandPair x}{snd x}]"
        | x :: xs -> loop $"{acc}{expandPair x}" xs
        | _ -> acc

    l |> List.pairwise |> loop "["

printfn "%A"
<| missingBits [ 1
                 2
                 3
                 4
                 20
                 21
                 22
                 23 ]

printfn "%A" <| missingBits [ 1; 2; 3; 5; 6 ]
printfn "%A" <| missingBits [ 1; 3; 20; 27 ]
