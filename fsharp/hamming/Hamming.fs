module Hamming

let distance (strand1: string) (strand2: string): int option = 
    if System.String.IsNullOrWhiteSpace(strand1) && System.String.IsNullOrWhiteSpace(strand2) then Some 0
    else Seq.map2(=) strand1 strand2 |> Seq.sumBy(fun b -> if b then 0 else 1)