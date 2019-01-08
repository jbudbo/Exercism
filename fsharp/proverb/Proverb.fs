module Proverb

let recite (input: string list): string list = 
    let baseList = 
        input
        |> List.windowed 2
        |> List.map (fun l -> sprintf "For want of a %s the %s was lost." l.[0] l.[1])

    match input with
    | [] -> []
    | _ -> baseList@[sprintf "And all for the want of a %s." input.Head]