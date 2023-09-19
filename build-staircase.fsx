#!/usr/bin/env -S dotnet fsi

// Recursively
let buildStaircase n =
    let rec loop blocks step =
        if blocks <= 0 then
            step - 1
        else
            loop (blocks - step - 1) (step + 1)

    loop n 1

// Solving for blocks = (s*s + s)/2
let buildStaircase2 blocks = int (0.5 * (sqrt (8. * blocks + 1.) - 1.))

printfn "%A" <| buildStaircase 6
printfn "%A" <| buildStaircase 9
printfn "%A" <| buildStaircase 11
printfn "%A" <| buildStaircase 54
printfn "%A" <| buildStaircase 55
printfn "%A" <| buildStaircase 56
printfn "%A" <| buildStaircase2 6
printfn "%A" <| buildStaircase2 9
printfn "%A" <| buildStaircase2 11
printfn "%A" <| buildStaircase2 54
printfn "%A" <| buildStaircase2 55
printfn "%A" <| buildStaircase2 56
