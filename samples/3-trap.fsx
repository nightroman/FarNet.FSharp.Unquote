open Swensen.Unquote

let x = "foo"
let y = "bar"

try
    let res = trap <@ 1 / (x.Length - y.Length) @>
    printfn "%i" res
with ex ->
    printfn "%A" ex
