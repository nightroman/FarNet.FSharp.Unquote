[/samples]: https://github.com/nightroman/FarNet.FSharp.Unquote/tree/main/samples
[FarNet.FSharpFar]: https://github.com/nightroman/FarNet/tree/master/FSharpFar
[Unquote]: https://github.com/SwensenSoftware/unquote

# FarNet.FSharp.Unquote

This package provides [Unquote] for [FarNet.FSharpFar]

> Write F# unit test assertions as quoted expressions, get step-by-step failure messages for free

## Installation

- Far Manager
- Package [FarNet](https://www.nuget.org/packages/FarNet)
- Package [FarNet.FSharpFar](https://www.nuget.org/packages/FarNet.FSharpFar)
- Package [FarNet.FSharp.Unquote](https://www.nuget.org/packages/FarNet.FSharp.Unquote)

How to install and update FarNet and modules:\
https://github.com/nightroman/FarNet#readme

Once installed, the package is portable with Far Manager and available for F# scripts.

## F# scripts

In your F# script directory create the configuration `*.fs.ini`:

```ini
[use]
%FARHOME%\FarNet\Lib\FarNet.FSharp.Unquote\FarNet.FSharp.Unquote.ini
```

Scripts normally use:

```fsharp
open Swensen.Unquote
```

This is it. See [/samples].

## See also

- [Release Notes](https://github.com/nightroman/FarNet.FSharp.Unquote/blob/main/Release-Notes.md)
- [Unquote]
