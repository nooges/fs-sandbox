#!/usr/bin/env -S dotnet fsi

let ordinal number =
    let rec suffix =
        function
        | 1 -> "st"
        | 2 -> "nd"
        | 3 -> "rd"
        | n when n < 14 -> "th"
        | n -> suffix (n % 10)

    string number + suffix (number % 100)

seq { 1..30 }
|> Seq.map ordinal
|> Seq.toArray
|> printfn "%A"

seq { 200..230 }
|> Seq.map ordinal
|> Seq.toArray
|> printfn "%A"

printfn "%A" <| ordinal 211
