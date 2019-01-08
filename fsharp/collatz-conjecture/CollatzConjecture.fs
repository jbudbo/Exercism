module CollatzConjecture

let steps (number: int): int option = 
    let (|Even|Odd|) x = if x % 2 = 0 then Even else Odd

    let rec processState state i =
        match state with
        | 1 -> i
        | Even -> processState (state / 2) (i + 1)
        | Odd -> processState (3 * state + 1) (i + 1)

    if number <= 0 then None else Some(processState number 0)

