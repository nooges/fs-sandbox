#!/usr/bin/env -S dotnet fsi

let solutionWord = "fudge"

let wordleGuess guess solution =
    let sharedLetters = Set.intersect (Set.ofSeq guess) (Set.ofSeq solution)

    let convertLetter g s =
        if g = s then
            "🟩"
        elif Set.contains g sharedLetters then
            "🟨"
        else
            "⬛"

    Seq.zip guess solution
    |> Seq.map (fun (g, s) -> convertLetter g s)
    |> System.String.Concat

printfn "%A" (wordleGuess "reads" solutionWord)
printfn "%A" (wordleGuess "lodge" solutionWord)
