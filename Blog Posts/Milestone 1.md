
# GMD1 - Gates of Hell - Milestone 1
## List of stuff done:
1. Player Model
2. Player Animation
3. Player Movement
## Player Model - Floating Eyeball (Made using Blender)
### Idea
As discussed previously, our player will be an eyeball monster. Since there were no similar prefabs in the unity asset store  I decided to make one of my own from scratch. 
There were a couple changes from the original plan though. First - I decided not to go for limbs and instead add some tentacles at the back. Second - I decided to add liveliness to the character by animating the tentacles and simulate its floating. As it may be quite obvious, this was inspired by Eye of Cthulhu from Terraria :)

![Final](https://github.com/user-attachments/assets/f92bac3b-e512-4447-9f05-8851232a1e3c)


### Execution
The process started by creating a 3D model. To achieve this I used 2 spheres. The first was made to create the tentacles at the back and the pupil + iris at the front. I painted the faces of the tentacles blood red and the iris blue + black. The second sphere was used to sculpt out blood vessels in the middle part of the eye. I decided to do this using a separate sphere because selecting faces for the sculpted blood vessels so I could paint them would have been very time consuming and painful process. The workaround for it was to paint the whole sculpted sphere red and then put it inside the first one, so only the blood vessels stick out. This turned out great :) 

![Solid](https://github.com/user-attachments/assets/4fdb358e-7730-4d33-8c58-b0730f462663)![Rendered](https://github.com/user-attachments/assets/371d6369-58aa-4808-a615-19a73147bb4e)


## Animation (Made using Blender and Unity)
### Bone animation
In order to breathe more life into the player character I decided to add some movement of the tentacles and the model as a whole. The tentacles were animated using bone movement in blender. Each tentacle had a series of connected bones that I rotated both ways and animated using key frames on blender.

![AnimatingTentacles-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/df2bd1b7-a5a7-4aa3-873e-d567319daa73)


### Unity Animator
The whole model + animation was then exported from Blender into Unity as an .fbx file. There I blended the loop of the animation and added it to the 3D game object. 

![Animator](https://github.com/user-attachments/assets/27dacef7-033c-47e3-a6b9-20dd040bcf45)


### Floating animation
As for making the whole character float, I decided to simulate that using a script on Unity, that interacts with with the objects local transform directly and edits its position on the Y axis, making it float up and down :)

![AnimatingFloating-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/259428c7-831d-42d0-8672-0977ae9aa2c7)


## Restricted Player Movement (Made using Unity)
### Idea
In order to make this a consistent platformer/dungeon crawler I decided to restrict the movement of the player, where they continuously move 1 meter at a time. If we get input while traveling that meter, we change direction only after we are done traveling said meter. We allow the player to stop moving only if they bump into a solid object. This can be done intentionally while moving along the object and turning to face it, which may introduce interesting routes players could take for extra safety. 

![EyeballMovementComplete-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/e47fe195-748d-471f-b436-d9bcd5dd7183)


### Execution
At game start, we snap the player’s position to the nearest whole unit. This ensures all movement happens cleanly on a grid and prevents floating-point drift over time.

![image](https://github.com/user-attachments/assets/e6f4f1be-70db-42cc-98b5-0e324446ecfc)


To keep movement restricted to 4 cardinal directions, we filter stick input to only allow the strongest axis (horizontal or vertical). This avoids accidental diagonal movement when tilting a joystick.

![image](https://github.com/user-attachments/assets/bb6abd7f-2ac6-45f0-907a-c915cecd9d2d)


The player moves in discrete "segments" (1 unit at a time). This allows us to ensure that the player is aligned and kept in bounds correctly at all stages of the game.

![image](https://github.com/user-attachments/assets/1e286538-9936-4b3e-afb8-99ed2cfc9d69)


To ensure player is restricted to the 1m segment-based movement, their input is buffered.

![image](https://github.com/user-attachments/assets/9bd554cb-20cd-49c6-949d-781e301a5150)


We use a short raycast to detect walls or obstacles before every move. This gives us pixel-perfect collision while keeping movement physics-free and grid-snapped.

![image](https://github.com/user-attachments/assets/f925edc6-fd50-4682-b957-27b8f94cf081)


Even if the player can't move (because of a wall), the eyeball still rotates to **face the direction you wanted to go**. This makes the game feel more responsive and visually aligned with input, while preserving the block-based movement system.

![image](https://github.com/user-attachments/assets/ccc12249-7b79-4c32-b91e-5fa0c3bd170f)

## Whats next?
After this work I have tried logically planned out my next moves and realized that my milestone order should be a bit different. Heres an updated list
1. Player Model + Movement - done
2. Traps and other game objects + interactions with the player
3. Level building + UI
