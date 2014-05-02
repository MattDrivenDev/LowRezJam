module Program
open LowRezJam

// ----------------------------------------------------------------------------
// NOTES:
// All applications need an entry point. This should look familiar enough.
// The program essentially loads the game and subscribes to the events being
// published and lets it get on with it.
// ----------------------------------------------------------------------------

[<EntryPoint>]
let main _ =  
  let game = new LowRezGame()
  let updateEvents, drawEvents = 
    game.Events
  
  game.Events
  |> Observable. 
  |> GameLoop.create game.PixelTexture
  |> Observable.
  game.Run()
  0 // return the magic exit code!