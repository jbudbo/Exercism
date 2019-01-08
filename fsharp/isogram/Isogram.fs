module Isogram

open System

let isIsogram (str:string): bool = 
    let anyPairs =
        str.ToLower()
        |> Seq.where (fun c -> Char.IsLetter c)
        |> Seq.sort
        |> Seq.pairwise
        |> Seq.exists (fun pair -> fst pair = snd pair)
    not anyPairs