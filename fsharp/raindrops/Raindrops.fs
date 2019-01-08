module Raindrops

let convert (number: int): string = 
    let rec getFactors num proposed acc =
        if proposed = num then
            proposed::acc
        elif num % proposed = 0 then
            getFactors (num/proposed) proposed (proposed::acc)
        else
            getFactors num (proposed+1) acc

    let x = getFactors number 2 []

    ""