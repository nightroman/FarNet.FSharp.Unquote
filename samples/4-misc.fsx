// https://subscription.packtpub.com/book/application-development/9781784391232/4/ch04lvl1sec34/unquote
// ~ Unquote vs FsUnit

open Swensen.Unquote

<@ (1+2)/3 @> |> reduceFully |> List.map decompile
|> printfn "%A"

unquote <@ [for i in 1..5 -> i * i] = ([1..5] |> List.map (fun i -> i * i)) @>
|> printfn "%A"
