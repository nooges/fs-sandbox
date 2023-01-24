namespace Boxcreek

module Utilities =

    let pp a = printfn "%A" a
    let (|?) = defaultArg // Option coalescing

    // Tee operator
    let (|>!) x sideEffect =
        sideEffect x |> ignore
        x
