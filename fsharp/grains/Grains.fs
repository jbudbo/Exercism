module Grains
 
let private valOf (i:int): uint64 = pown 2UL (i-1)

let square (n: int): Result<uint64,string> =
    match n with
    | i when i <= 64 && i >= 1 -> Ok (valOf n)
    | _ -> Error "square must be between 1 and 64"
    
let total: Result<uint64,string> = 
    let total = [|1..64|] |> Array.sumBy (fun x -> valOf x)
    Ok total