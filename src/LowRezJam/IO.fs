module IO
open Domain
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics

let create inputs = { movement = fst inputs; shooting = snd inputs; }
  
let readPlayerMovement (keyboard:KeyboardState) = 
  if keyboard.IsKeyDown(Keys.W) then Some Up
  else if keyboard.IsKeyDown(Keys.S) then Some Down
  else if keyboard.IsKeyDown(Keys.A) then Some Left
  else if keyboard.IsKeyDown(Keys.D) then Some Right
  else None

let readPlayerShooting (keyboard:KeyboardState) = 
  if keyboard.IsKeyDown(Keys.Up) then Some Up
  else if keyboard.IsKeyDown(Keys.Down) then Some Down
  else if keyboard.IsKeyDown(Keys.Left) then Some Left
  else if keyboard.IsKeyDown(Keys.Right) then Some Right
  else None

let readPlayerInput keyboard = 
  (readPlayerMovement keyboard, readPlayerShooting keyboard) |> create

let drawPixel (texture:Texture2D) (spritebatch:SpriteBatch option) x y pixel = 
  match spritebatch with
  | Some batch ->
    let draw color = batch.Draw(texture, new Rectangle(scale x, scale y, scale 1, scale 1), color)  
    batch.Begin()
    match pixel with
    | White -> draw Color.White
    | Black -> draw Color.Black
    batch.End()
  | None -> ()

let createRenderer texture =     
  MailboxProcessor<ScreenBuffer * SpriteBatch option>.Start(fun inbox ->
    let rec renderLoop = async {
      let! (ScreenBuffer buffer, spritebatch) = inbox.Receive()
      buffer |> Array2D.iteri (drawPixel texture spritebatch)
      return! renderLoop }
    renderLoop )