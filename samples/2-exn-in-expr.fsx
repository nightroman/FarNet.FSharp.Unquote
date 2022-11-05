open Swensen.Unquote

type Rec1 = { Name: string }
let rec1 = { Name = null }

let expr = <@ rec1.Name.Length = 42 @>

raises<AssertionFailedException> <@ test expr @>

try
    test expr
with ex ->
    printfn "%A" ex
