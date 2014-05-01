module LowRezJam
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type LowRezGame() as this = 
  inherit Game()
  
  let scale x = x * 20
  let graphics = new GraphicsDeviceManager(this)
  let mutable spritebatch = Unchecked.defaultof<_>
  let mutable pixel = Unchecked.defaultof<_>
  let rect = new Rectangle(x = scale 10, y = scale 10, width = scale 1, height = scale 1)

  do    
    graphics.PreferredBackBufferWidth <- scale 32
    graphics.PreferredBackBufferHeight <- scale 32
    graphics.GraphicsProfile <- GraphicsProfile.HiDef
    graphics.IsFullScreen <- false

  override this.LoadContent() = 
    spritebatch <- new SpriteBatch(graphics.GraphicsDevice)
    pixel <- this.Content.Load<Texture2D>("pixel")

  override this.Update(gametime) = 
    ()
    
  override this.Draw(gametime) = 
    graphics.GraphicsDevice.Clear(Color.White)
    spritebatch.Begin()
    spritebatch.Draw(pixel, rect, Color.GreenYellow)
    spritebatch.End()

[<EntryPoint>]
let main _ =
  let game = new LowRezGame()
  game.Run()
  0 // return the magic exit code!