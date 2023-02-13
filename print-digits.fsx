#!/usr/bin/env -S dotnet fsi

[ 0 .. int 'd' ] |> List.iter (printfn "%d")
