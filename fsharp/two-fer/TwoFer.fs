module TwoFer

let twoFer (input: string option): string = 
    let formatString (input: string): string=
        sprintf "One for %s, one for me." input

    match input with
    | Some x -> formatString x
    | None -> formatString "you"