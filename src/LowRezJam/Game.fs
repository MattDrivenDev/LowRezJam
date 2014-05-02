module LowRezJam
open Domain
open IO
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

// ----------------------------------------------------------------------------
// NOTES:
// Here lies the horrible OOP part of the game. The goal here is to minimize
// the imperative style and simple publish events and store mutable state
// that can then flow through the pure functions throughout the game.
// ----------------------------------------------------------------------------

type LowRezGame() as this = 
  inherit Game()
  
  let graphics = new GraphicsDeviceManager(this)
  let mutable spritebatch = Option<SpriteBatch>.None
  let mutable pixel = Unchecked.defaultof<_>
  let gameEvent = new Event<GameEvent>()

  let readPlayerInput() = 
    Microsoft.Xna.Framework.Input.Keyboard.GetState() |> readPlayerInput

  do    
    graphics.PreferredBackBufferWidth <- scale 32
    graphics.PreferredBackBufferHeight <- scale 32
    graphics.GraphicsProfile <- GraphicsProfile.HiDef
    graphics.IsFullScreen <- false

  member this.Events = gameEvent.Publish

  override this.LoadContent() = 
    spritebatch <- Some (new SpriteBatch(graphics.GraphicsDevice))
    pixel <- this.Content.Load<Texture2D>("pixel")

  override this.Update(gametime) = 
    (gametime, readPlayerInput()) 
    |> UpdateEvent
    |> gameEvent.Trigger 

  override this.Draw(gametime) = 
    (spritebatch, pixel)
    |> DrawEvent
    |> gameEvent.Trigger