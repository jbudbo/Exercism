module RobotName

open System

let private random = new Random()
let private letters = Seq.init 2 (fun _ -> [|'A'..'Z'|].[random.Next 26] |> string)
let private numbers = Seq.init 3 (fun _ -> [|0..9|].[random.Next 10] |> string)

let mkRobot() = failwith "You need to implement this function."

let name robot = failwith "You need to implement this function."

let reset robot = failwith "You need to implement this function."