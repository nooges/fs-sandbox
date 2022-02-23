#!/usr/bin/env -S dotnet fsi

let longestSubSeq s =
    let longestRun s =
        let rec loop longest acc a =
            match a with
            | [] -> max longest acc
            | 1 :: tail -> loop longest (acc + 1) tail
            | _ :: tail -> loop (max longest acc) 1 tail

        loop 1 1 s

    s
    |> List.sort
    |> List.pairwise
    |> List.map (fun (a, b) -> b - a)
    |> longestRun

let a1 = [ 1; 9; 87; 3; 10; 4; 20; 2; 45 ]

let a2 =
    [ 36
      41
      56
      35
      91
      33
      34
      92
      43
      37
      42 ]

printfn "%A" <| longestSubSeq a1
printfn "%A" <| longestSubSeq a2
printfn "%A" <| longestSubSeq [ 5; 7 ]
