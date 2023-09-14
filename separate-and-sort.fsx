#!/usr/bin/env -S dotnet fsi

let separateAndSort =
    List.sort
    >> List.filter (fun n -> n <> 0)
    >> List.partition (fun n -> n % 2 = 0)

printfn "%A" <| separateAndSort [4;3;2;1;5;7;8;9]
printfn "%A" <| separateAndSort [1;1;1;1]
printfn "%A" <| separateAndSort [4;3;2;0;1;5;7;8;9]