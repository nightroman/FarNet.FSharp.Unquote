open Swensen.Unquote

let x = "foo"
let y = "bar"

try
    // `trap` evaluates the given expression and returns its value.
    // But if the expression throws, `trap` works like `test`.
    let res = trap <@ 1 / (x.Length - y.Length) @>

    // this is not called due to the above exception
    printfn "%i" res

with ex ->
    // show the exception explained
    printfn "%A" ex
