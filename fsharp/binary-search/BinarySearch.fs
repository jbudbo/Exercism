module BinarySearch

let find input value = 
    let rec subFind input value offset =
        match Array.length input with
        | 0 -> None
        | len -> 
            let midpoint = len / 2
            match compare value input.[midpoint] with
            | 0 -> Some (offset + midpoint)
            | -1 -> subFind input.[..midpoint-1] value offset
            | 1 -> subFind input.[midpoint+1..] value (offset + midpoint + 1)
            | _ -> None

    subFind input value 0