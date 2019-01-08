namespace ProteinTranslation.Helpers

open System.Runtime.CompilerServices

[<Extension>]
module Extensions =

    [<Extension>]
    let ToChunks (str:string) len = 
        str 
        |> Seq.chunkBySize len 
        |> Seq.where (fun cs -> Array.length cs = len)
        |> Seq.map (fun cs -> cs |> Array.map string |> Array.reduce (+))