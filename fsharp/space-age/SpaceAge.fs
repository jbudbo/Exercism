module SpaceAge

type Planet = Mercury | Venus | Earth | Mars | Jupiter | Saturn | Uranus | Neptune

let age (planet: Planet) (seconds: int64): float = 
    let baseline seconds = (float seconds) / 31557600.0

    match planet with
    | Mercury -> baseline seconds / 0.2408467
    | Venus -> baseline seconds / 0.61519726
    | Earth -> baseline seconds
    | Mars -> baseline seconds / 1.8808158
    | Jupiter -> baseline seconds / 11.862615
    | Saturn -> baseline seconds / 29.447498
    | Uranus -> baseline seconds / 84.016846
    | Neptune -> baseline seconds / 164.79132