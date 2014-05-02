module Program
open LowRezJam

[<EntryPoint>]
let main _ =
  let game = new LowRezGame()
  game.Run()
  0 // return the magic exit code!