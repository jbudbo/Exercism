module Darts

let score (x: double) (y: double): int = 
    match sqrt (x * x + y * y) with
    | s when s > 10.0 -> 0
    | s when s > 5.0 -> 1
    | s when s > 1.0 -> 5
    | _ -> 10
