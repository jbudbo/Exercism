module Bob

let response (input: string): string = 
    let anyLetters (x: string): bool = x |> Seq.exists(fun c -> System.Char.IsLetter(c))
    let isQuestion (x: string): bool = x.Trim().EndsWith "?"
    let isLoud (x: string): bool = x.ToUpper().Equals x
    match input with
    | q when anyLetters q && isLoud q && isQuestion q -> "Calm down, I know what I'm doing!"
    | q when anyLetters q && isLoud q -> "Whoa, chill out!"
    | q when System.String.IsNullOrWhiteSpace q -> "Fine. Be that way!"
    | q when isQuestion q -> "Sure."
    | _ -> "Whatever."