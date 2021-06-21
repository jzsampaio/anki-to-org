open System
open System.IO

let toOrg (a, b) =
    $"""
* Item :drill:

{a}

** Answer

{b}
    """

[<EntryPoint>]
let main argv =
    let (inputFile :: xs) = Array.toList argv

    let lines = File.ReadLines inputFile

    lines
    |> Seq.map (fun x -> x.Split([| '\t' |]))
    |> Seq.map Array.toList
    |> Seq.map (fun (a :: b :: xs) -> (a, b))
    |> Seq.map toOrg
    |> Seq.iter (fun x -> printfn $"{x}")
    |> ignore
    0
