module ArmstrongNumbers

let isArmstrongNumber (number: int): bool = 
    let rec splitNumbers num =
        seq {
            if num > 0 then
                yield num % 10
                yield! splitNumbers (num / 10)
        }
    
    let numSet = Seq.toArray (splitNumbers number)

    let pow = numSet.Length

    numSet
    |> Array.sumBy (fun x -> pown x pow)
    |> (=) number