#!/usr/bin/env -S dotnet fsi

let solutionWord = "fudge"

let wordleGuess guess solution =
    let sharedLetters = Set.intersect (Set.ofSeq guess) (Set.ofSeq solution)

    let convertLetter g s =
        match g with
        | g when g = s -> "🟩"
        | g when Set.contains g sharedLetters -> "🟨"
        | _ -> "⬛"

    (guess, solution)
    ||> Seq.map2 convertLetter
    |> System.String.Concat

printfn "%A" (wordleGuess "reads" solutionWord)
printfn "%A" (wordleGuess "lodge" solutionWord)
