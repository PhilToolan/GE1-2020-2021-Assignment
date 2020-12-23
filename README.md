# GE1-2020-2021-Assignment
 
# Philip Toolan, DT282, C17433026

## Description:
The assingment will be a series of audio visual experiences. There is 3 experiences available: "Pong Effect", "Retrowave" and "The Club". Pong Effect is a simple game of pong 
that takes place while travelling through a procedural world. Retrowave is a simple audio visualisation that uses lots of post processing effects to get a synthwave feel to the 
visual. The club is an audio visualisation that takes place while travelling through an endless procedural tunnel. I had to recreate the repo during the assignment so here is 
the original repo to track the commits: https://github.com/PhilToolan/GE1-2020-2021-Assingment. Each experience will be broken down by GameObject in this explanation.

## Pong Effect

### Description
Pong Effect is essentially a mix of *Tetris Effect* and *Super Hexagon*. The player travels through an infinite procedural world while trying to keep a ball from going off the 
screen. The idea is to allow the user to lose themselves in the music and take a break from the real world.

#### Terrain
The terrain object holds the prefab of the terrain tile. It also has the script "InfiniteTerrain" added to it. This script controls the placement of the terrain. It is a lightly 
edited version of the script we used in the labs.
#### TerainTile
The terain tile is stored as a prefab and is spawn at runtime by Terrain. It has the script TerrainTile attached to it and has the material TerrainMaterial. TerrainTile controls 
the geometry of the terrain, it is similar to one used in the labs where mountains and valleys are made with the terrain and perlin noise is added to prevent it from being too 
smooth. 
#### Player
The player has two scripts attached, fly over and player movement. Fly over controls the movement over the terrain and player movement controls the movement of the camrea and 
some scene management. The camera that move through the scene is added as a child and two particle effects are added as children of the camera. These make you feel more like you 
are moving. Fog is also added to the scene lighting for this camera so the user cannot see the world being generated in front of them.
#### Ball
The ball is a simple circle. It has an audio source component attached, a trail renderer and the script Ball. The script controls all the aspects of the game: sound effects, 
ball movement, score text.
#### PongPlayer
The PongPlayer controls the player movement in the game of pong. There is a gameobject in the middle of the screen that draws a raycast in the direction of the mouse. Where this
raycast hits a boundary is where the paddle moves. Everytime the ball collides with a paddle the score increases and the movement of the ball goes in the opposite direction.
#### Camera2D
This camera only sees the gameobjects of the pong game, the two cameras in the scene are layered. This allows us to move through a 3D space while playing a 2D game.
#### Frames and Paddles
The Frames are just colliders on each side of the game, where the raycast from Player collides with the frame is where the paddle moves to. There is two paddles in the scene one 
for the sides and one for top and bottom. 
#### GameMusic
Plays the music.
#### Canvas
This displays the score UI to the player.

## Retrowave

### Description
Retrowave is a simple audio visualiser that leans heavily on the synth wave style of the 1980s.

#### Main Camera
Follows the car asset. Post processing layer added to the camera to facilitate the effects of the scene. There is no fog in this scene as the idea of the ground being generated 
in front of you leans into the aesthetic of the scene.
#### Terrain
This is much the same as Terrain in Pong Effect, it is being sampled differently so that the terrain is completely smooth and flat again adding to the aesthetic. The material 
used on the terrain tile here is different however. This is a custom material made in photoshop, it consists of a simple png of the desired pattern in the desired colour and an 
identical png that is in black and white. The black and white png is used as an emission map on the material and allows the material to glow in the correct areas when a bloom 
effect is put on the camera with Post processing. 
#### Car
The car is the one asset imported for the assignment. It came with its own textures, materials and mesh. Added to the car is 2 trail renderers, a camera target and the audio 
visualiser. The audio visualiser is a child of the car object as it will then always be the same distance away from the car. The visualiser is similar to the visualiser used in 
the audio lab, it has a custom shader on it that allows the material to change colour at certain Y values. 
#### Audio Analyzer
The audio analyzer takes in the music and splits it into 7 different frequency bands.
#### PostProcessing
This gameobject holds all the postprocessing effects in the scene, Bloom, Grain, Vignette, chromatic aberration and color grading.
#### SkyBox
Is custom skybox was made for the scene in Photoshop, it consists of 6 different images which form the skybox of the scene. This further adds to the aesthetic of the scene.

## The Club

### Description
The Club is another audio visualiser that allows the user to *feel* the music. It achieves this by making a procedural tunnel that the user travels through with a visualiser.

#### The Tunnel
The tunnel is created by making a [Torus](https://en.wikipedia.org/wiki/Torus). This Torus 
is then split up into different sections to make a tunnel. Each tunnel will add up to a total of 360 degrees but it is ensured that the tunnel does not loop back on 
itself so that it can twist and wind endlessly. Each tunnel's first vertices are the same as the previous tunnels last vertices to ensure that they line up correctly. There is a 
certain amount of randomness added to the curve of the tunnel and the amount of segments to the tunnel, this makes the tunnel feel more twisty and windy and less repetitive.
At first, to move through the tunnel I used raycasts but this was not ideal as the tunnel is not perfectly smooth so it felt quite bumpy to the user and actually made me feel 
motion sickness at times. To solve this problem the movement is done in the opposite. The tunnel moves towards the camera and the camera always remains at the origin. This 
worked well but you couldnt feel the twists and turns of the tunnel. To solve this issue the whole tunnel system is rotated with each tunnel so basically the world rotates and 
moves around the camera while it stays perfectly still. 
A shader is applied to the material of the tunnel that changes colour from the origin of the world. This adds another feeling of momentum and makes the experience more exciting. 
#### Audio Viz 2
This is an editied version of a tutorial by Peerplay on [Procedural Phyllotaxis](https://www.youtube.com/watch?v=kNEEvGFU7m0). It uses the same audio analyzer script from the 
other visualisation. It consists of a trail renderer where its movement is controlled by the music. There is also a sphere with the same material on it that is used in the 
retrowave scene. A light is shone from the trail onto the ball, as it gets to the emmissive part of the material it shines brighter thanks to a bloom effect on the camera from 
postprocessing, this a nice effect which adds to the spectacle of the scene.
#### The Cameras
Like in Pong Effect, there is two cameras used and they are layered on each other. The camera for audioviz2 is set as depth only and is layered on top of the main camera which 
sees the tunnel.


## What I am most proud of
I am most proud of the tunnel system. It took a lot of time and headaches to implement but I believe the result I came out with looks great.



## Resources

Some of the generic resources I have researched for this assignment are:
- https://forum.unity.com/threads/audio-visualization-tutorial-unity-c-q-a.432461/
- http://www.41post.com/4776/programming/unity-making-a-simple-audio-visualization
- https://github.com/aldrinabastillas/Audio-Visualizer
- https://youtu.be/bV0WvCi83UM

The research for Pong Effect:
- https://www.youtube.com/watch?v=Mr8fVT_Ds4Q
- https://www.youtube.com/watch?v=2sz0mI_6tLQ
- https://www.youtube.com/watch?v=YHSanceczXY

The research and resources for Retrowave:
- https://www.youtube.com/watch?v=YgFaowd-Ui0
- https://www.youtube.com/watch?v=HODpmgymExQ
- https://www.youtube.com/watch?v=HPHP9bWuQvc
- https://www.youtube.com/watch?v=PgXZsoslGsg
- https://www.youtube.com/watch?v=KVYYMDDUgqY
- https://www.youtube.com/watch?v=Nd1pmR1afGk
- https://assetstore.unity.com/packages/3d/vehicles/land/shaded-free-retro-car-179873
- https://www.polycarbongames.com/single-post/synthwave-skybox

The research for The Club:
- https://www.youtube.com/watch?v=cRSqM-67EiE
- https://www.youtube.com/watch?v=eTP_8NXwyNE
- https://www.youtube.com/watch?v=IsDfnIbshj4
- https://www.youtube.com/watch?v=wtXirrO-iNA
- https://www.youtube.com/watch?v=kNEEvGFU7m0
- https://en.wikipedia.org/wiki/Torus
- https://www.youtube.com/watch?v=MXm9OmzRe2o&list=PL1n0B6z4e_E5qaYwUOlJ63XI2OR9ty7Bs
