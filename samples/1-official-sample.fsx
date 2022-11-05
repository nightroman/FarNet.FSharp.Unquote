open Swensen.Unquote

let expr = <@
    ([3; 2; 1; 0]
    |> List.map ((+) 1)) = [1 + 3..1 + 0]
@>

raises<AssertionFailedException> <@ test expr @>

try
    test expr
with ex ->
    printfn "%A" ex

decompile expr
|> printfn "\ndecompile\n%s"

expr
|> printfn "\nToString\n%O"
