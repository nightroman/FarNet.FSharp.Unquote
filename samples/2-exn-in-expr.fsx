open Swensen.Unquote

type Data() =
    member val Name: string = null

// this expression fails due to an exception, not false result
let expr = <@ Data().Name.Length = 42 @>

// Unquote `test` explains where and why the exception happens
try
    test expr
with ex ->
    printfn "%O" ex

// (just to be sure that it throws as expected)
raises<AssertionFailedException> <@ test expr @>
