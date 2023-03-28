#!/usr/bin/env -S dotnet fsi

let rollDie faces = System.Random().Next(1, faces)

let rollDice =
    fun (s: string) -> s.Split '+'
    >> Array.sumBy (fun s ->
        (s.Split 'd'
         |> fun a ->
             [ 1 .. int a[0] ]
             |> List.sumBy (fun _ -> rollDie (int a[1]))))

printfn "%A" <| rollDice "4d4"
printfn "%A" <| rollDice "3d20"
printfn "%A" <| rollDice "1d8+2d10"
