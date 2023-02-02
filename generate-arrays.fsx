#!/usr/bin/env -S dotnet fsi

let generateArrays n =
    [| 1..n |] |> Array.map (fun i -> [| 1..i |])

printfn "%A" <| generateArrays 4
printfn "%A" <| generateArrays 1
