module Domain
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Pixel = | Black | White
type ScreenBuffer = ScreenBuffer of Pixel [,]
type Direction = | Up | Down | Left | Right
type PlayerInput = { movement: Direction option; shooting: Direction option }
type GameObject = | Player
type GameState = { map: GameObject option [,] }
type GameEvent = 
  | UpdateEvent of GameTime * PlayerInput
  | DrawEvent of SpriteBatch option * Texture2D

let emptyMap = 
  Array2D.create<GameObject option> 32 32 None

let placePlayer x y = 
  Array2D.mapi (fun i j _ -> if x = i && y = j then Some Player else None)

let createGameState = 
  { map = emptyMap |> placePlayer 16 18 }  

let buffer (state:GameState) = 
  Array2D.create 32 32 White |> ScreenBuffer