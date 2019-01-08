module Pangram

open System

let isPangram (input: string): bool = 
    input
    |> Seq.where (fun c -> Char.IsLetter(c))
    |> Seq.distinctBy (fun c -> Char.ToLower(c))
    |> Seq.length
    |> (=) 26