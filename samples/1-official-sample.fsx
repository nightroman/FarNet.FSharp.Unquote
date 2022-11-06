open Swensen.Unquote

// this expression is `false` but this might be hard to see
let expr = <@ ([3; 2; 1; 0] |> List.map ((+) 1)) = [1 + 3 .. 1 + 0] @>

// test it, catch exception, show this `false` explained
try
    test expr
with ex ->
    printfn "%O" ex

// `raises` asserts particular exception type,
// AssertionFailedException in this case
raises<AssertionFailedException> <@ test expr @>

// `decompile` gives source code representation
decompile expr
|> printfn "\ndecompile\n%s"

// `unquote` gives UnquotedExpression
// printf "%A" shows evaluation steps
unquote expr
|> printfn "\nunquote\n%A"
