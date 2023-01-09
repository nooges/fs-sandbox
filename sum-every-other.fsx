#!/usr/bin/env -S dotnet fsi

let sumEveryOtherCharDigit =
    Seq.mapi (fun i c -> (i % 2) * (c |> string |> int))
    >> Seq.sum

let sumEveryOtherFloat =
    string
    >> Seq.filter System.Char.IsDigit
    >> sumEveryOtherCharDigit

let sumEveryOther = string >> sumEveryOtherCharDigit

printfn "%A" <| sumEveryOther 548915381
printfn "%A" <| sumEveryOther 10
printfn "%A" <| sumEveryOtherFloat 1010.11
