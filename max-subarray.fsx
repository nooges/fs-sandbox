#!/usr/bin/env -S dotnet fsi

let maxSubarray arr n =
    arr |> Array.windowed n |> Array.maxBy Array.sum


printfn "%A"
<| maxSubarray [| -4; 2; -5; 1; 2; 3; 6; -5; 1 |] 4

printfn "%A" <| maxSubarray [| 1; 2; 0; 5 |] 2
