// https://stackoverflow.com/a/15324536/323582

open Microsoft.FSharp.Linq.RuntimeHelpers

LeafExpressionConverter.EvaluateQuotation <@ 1 + 2 @>
|> printfn "%A"

let fn1 = LeafExpressionConverter.EvaluateQuotation <@ fun y -> y + 1.0 @> :?> double -> double

fn1 10
|> printfn "%A"
