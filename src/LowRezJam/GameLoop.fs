module GameLoop
open Domain
open IO
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

let update (state:GameState) (inputs:GameTime * PlayerInput) = 
  state

let create (texture:Texture2D) (events:IEvent<GameTime * PlayerInput>) =   
  let renderer = createRenderer texture
  events   
  |> Observable.scan update createGameState
  |> Observable.map buffer
  //|> Observable.subscribe renderer.Post