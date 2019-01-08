module Triangle

let private eval (lst: float list, i: int) =
    let processLst (l: float list) =
        let equality (l: float list): bool = l.Item 0 + l.Item 1 >= l.Item 2 && l.Item 1 + l.Item 2 >= l.Item 0 && l.Item 2 + l.Item 0 >= l.Item 1

        if not (equality lst) then None
        else
            match List.distinct l with 
            | x when (List.exists ((=) 0.0) x) -> None
            | x -> Some x.Length

    match processLst lst with
    | Some x -> x = i
    | None -> false

let equilateral triangle = eval(triangle, 1)

let isosceles triangle = eval(triangle, 1) || eval(triangle, 2)

let scalene triangle = eval(triangle, 3)