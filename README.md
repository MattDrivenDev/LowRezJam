# lowrezjam

Having a crack at [LowRezJam 2014](http://jams.gamejolt.io/lowrezjam2014) using [MonoGame](http://www.monogame.net/) and [F#](http://fsharp.org/).

## Notes

* The game is built at a resolution of `32x32` pixels - which I'm scaling up by 20 so that the actual view area is now `640x640`.
* The **only** graphical asset is the `pixel.xnb` which is a `1x1` grey png file compiled to the XNA/MonoGame 2D texture filetype. This get's scaled up when drawn to the screen.
* Going to try an treat the update loop as an event stream to fold over... where the state is a some kind of *game state object*.
* I want to experiment with rendering to a screen buffer which will be some kind of `pixel [,]` and then draw that to the screen using the spritebatch. I want to try and do this with/in a `MailboxProcessor` (F# in-proc agent).