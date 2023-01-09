#!/usr/bin/env -S dotnet fsi

let sumEveryOtherCharDigit s =
    s
    |> Seq.filter System.Char.IsDigit
    |> Seq.mapi (fun i c -> (i % 2) * (c |> string |> int))
    |> Seq.sum

let sumEveryOther n = n |> string |> sumEveryOtherCharDigit

let sumEveryOtherFloat (n: float) = n |> string |> sumEveryOtherCharDigit

printfn "%A" <| sumEveryOther 548915381
printfn "%A" <| sumEveryOther 10
printfn "%A" <| sumEveryOtherFloat 1010.11
