module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int = values |> List.last

let highest (values: int list): int = values |> List.max

let top  (values: int list): int list = values |> List.sortDescending |> List.truncate 3

let report (values: int list): string = 
    let localHighest = highest values
    let localLatest = latest values
    let report = sprintf "Your latest score was %i. " localLatest

    let report2 = 
        match localLatest with 
        | i when i = localHighest ->  "That's your personal best!"
        | i when i < localHighest -> sprintf "That's %i short of your personal best!" (localHighest - i)
        | i when i > localHighest -> sprintf "That's %i more than your personal best!" (i - localHighest)
        | _ -> null

    report + report2