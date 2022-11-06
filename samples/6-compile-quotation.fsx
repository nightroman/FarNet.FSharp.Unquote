// How to evaluate and compile quotations (Unquote is not needed)

open Microsoft.FSharp.Linq.RuntimeHelpers

// evaluate a value
let value = LeafExpressionConverter.EvaluateQuotation <@ 1 + 2 @>
printfn "%A" value

// compile a function
let add1 = LeafExpressionConverter.EvaluateQuotation <@ fun y -> y + 1.0 @> :?> double -> double

// call the function
add1 10
|> printfn "%f"

// test

open Swensen.Unquote

test <@ value :?> int = 3 @>
test <@ add1 10 = 11 @>
