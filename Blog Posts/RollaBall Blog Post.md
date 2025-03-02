
# GMD1 - Roll-A-Ball by Rojus Paukste
Hello! This is my first blog post for the GMD1 course :) In this blog post I will discuss some important details about my version of the Roll-A-Ball game. 
## Player
### Design
For the player, I have chosen to reuse an asset from my groups XRD1 project. Not sure why, but I really liked the idea of the ball rolling around being an eyeball. It felt cute and hell-ish at the same time, which kind of inspired the rest of the games thematic. 
![image](https://github.com/user-attachments/assets/b2be8039-2116-4300-bb96-e8c2c27c67d6)
### Controlls
The player moves around using ***W***+***A***+***S***+***D*** keys. On key press we inflict a force on the player object (movement vector X speed) which gives us a nice satisfying rolling ball. **Note**: my friends and I discovered a bit of a bug regarding player collision with the enemy model if we don't move at all at the start of the game. To fix this issue, we decided to take the simple way of giving the player a slight kick in the butt by forcing barely noticeable instance of movement.
![PlayerMove-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/005d9419-affa-464f-a3cb-f47237b1905e)
## Arena
### The looks
Though the layout of the arena is basic, similar to the end result in the tutorial, I improved it with some imported textures from the Unity Asset store to start building on the Hell theme. As we can see we have a couple walls, a random sphere and a ramp to make the layout a bit more interesting to play in.
![image](https://github.com/user-attachments/assets/bdecd03e-ef59-4000-ae5d-5c07b9d8a6dd)
### Navigation Mesh
A navigation mesh was baked to allow the enemy AI to navigate the arena towards the player with ease. I am very happy to point out that the mesh also covers the ramp and the narrow top of the wall on the South-East corner of the map. 
![image](https://github.com/user-attachments/assets/d55789f4-7ed2-48f3-84c2-a20a5ac18b41)
## Collectibles
For the collectibles I have chosen to use an imported prefab of a low poly fireplace to go along the theme of the game. I have also added texture to the particles to make it look a bit better. I am very satisfied with the end result.
![GameCollectible-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/274971f7-23fe-4059-aa62-2ee11bebfb3c)
## Enemy
### Character design + animation
For the enemy design I decided to play around with a more humanoid unity asset. I imported the 'Devil Woman' player avatar to chase around our cute little eyeball. 
![image](https://github.com/user-attachments/assets/2d5d67c2-cd82-4957-8215-c8933a3ae020)
I assigned her a rolling animation on loop from an RPG animation pack purely for the funnies and the irony :D
![GameEnemy-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/b7010656-92d6-4edb-b404-173e13fcfd0d)
### Enemy AI navigation
Of course part of the tutorial was to create the enemy AI script to navigate towards the position of the player. This worked out pretty well, I had no changes made to that. 
![PlayerMove-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/2bd7c02c-0116-4ab0-9c8a-68338943e751)
## Dynamic game objects
I have added a few stacks of cubes and a few small balls laid all around the arena. The objects have physics and can be interacted with by the player. They also have their own lava/rock texture to fit the Hell theme :)
![DynamicObject-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/763a5857-116b-42ea-8aec-0c1ad1274f1b)
## Game states + UI
### Start of game
I decided to add a starting condition of the game so were not immediately thrown into the action. For some reason I really hated how static the game looked until you started, so I decided to pause the enemy and player movement, but keep the scene live so we can see the fires burning and the enemy rolling in place, which gave it a way more satisfying and immersive feeling :D
![GameStart-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/72b3e6e5-5dc2-46b9-a736-35ef7121aa1a)
### Game lost
The only condition of loosing we have in this game is if we get caught by the enemy. Our player character is destroyed and we are greeted with the game lost UI.
![GameLoose-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/aebf1527-38f4-4a67-80f3-c96f06ffa482)
### Game won
We win the game if we collect all the collectable game objects around the arena. Once we win the enemy object is destroyed and we are greeted with the game won UI.
![GameWin-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/10a4a288-1fd6-4cee-b8df-3fcddeb6ae6d)
### Restart game
At any point of the game, win, loss, in progress, etc. we can hit the ***R*** key to restart the game. We scene is then reloaded and were back at the start screen/state.
![GameRestart-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/eb0e759b-f04d-4dc8-b595-e9a2796230e0)
## Summary
Overall, I am happy with the end result, though the level design is not far from the basics, I believe playing around with models, assets, animations, textures was a fun and valuable experience and I look forward to creating my own game :)
