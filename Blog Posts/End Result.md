# GMD1 - Gates of Hell - End Result
## Introduction
This milestone focuses on summarizing the end result of the project. The final Hand-in version of the game contains the following:
1. Eyeball player model
2. Traps:
	2.1. Sawmill
	2.2. Spikes
	2.3. Blade Swing
	2.4. Arrow Turret
	2.5. Spinning Flamethrower 
	2.6. Gates
	2.7. Pits
3. Scenes:
	3.1. Start screen
	3.2. Level 1
	3.3. Level 2
	3.4. End Credits
4. UI Elements
5. Respawning
6. Music

## Player character
I have created a custom made 3D model for our player character. It is a low-poly flying eyeball demon that traverses through hell. The 3D model also comes with animated tentacles at the back. We are simulating the floating of the character through a unity script. The player movement is restricted to a grid where 1 tile is 1x1 meters in unity. The player can move forwards, backwards, left and right. The player input is buffered so we change directions only after moving 1 tile. The player can bump into structures, in which case they stop moving and remain facing the object they bumped into. Here's the result:

![Moving-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/976c42db-3938-450d-9442-b4accfe3f3d0)

## Traps
I have implemented 5 types of traps to be used around the levels. The traps have death colliders with which upon contact the player character is killed. They all function in different ways and are meant to act as obstacles for the player to conquer. Here's every trap in action:
### Sawmill
![Sawmill-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/314e4325-205d-4667-a422-aef1c2281735)

### Spikes
![Spikes-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/42b70465-584e-40d1-bef5-c7fbc1cb80df)

### Blade swing
![BladeSwing-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/c872af03-1c59-459f-9f95-88efef374b25)

### Arrow Turret
![Arrows-Trim-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/9687f5c1-0fdd-42fb-9b79-8e4ddc49da9c)

### Spinning Flamethrower
![Flamethrower-Trim-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/2f3f2dc1-cea6-4630-8147-02100266df5f)

### Pits
![Pits-Trim-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/f3de44b6-9683-4eae-bb3d-0261ba237d00)

### Gates
Gates are a special interactable object. The player can open them by stepping on a plate, in which case they have 10 seconds to get past them before they close again.

![Gates-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/7ca09abd-ae12-41f6-95f9-d1b7aa740a54)

## Scenes
I have created 4 scenes. 1 intro scene, 1 end credit scene and 2 levels. 
### Start Screen
![Desktop2025 06 06-03 51 56 36 DVR-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/84335953-ef87-4d0c-85e1-fda785119e7a)

### Level 1
![Level1cut-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/4f5e29e3-19aa-43a4-a657-5495490bb6d8)

### Level 2
![Level2cut-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/73adc0c1-7f2c-4b94-b84a-71f5492498da)

### End Credits
![EndCredits-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/46f7fd07-94a3-42cf-8f87-69e0c9bafb17)

## UI elements
I have created various UI elements through 'Canva' and used them to design the UI layout inside unity. Here is a few examples:
### Death Message
![image](https://github.com/user-attachments/assets/4f47c042-b7b1-4265-9ef8-60e73de8d6df)

### Level Passed Message
![image](https://github.com/user-attachments/assets/5b0648c4-0e7f-4e74-85ad-2d4364660034)

## Player death and respawning
Our player character can die from traps or by falling off the map. After player death we are greeted with an option to respawn or go to start screen.
### Instant death
![Diefromtrapandrespawn-Trim-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/cf43621e-2d31-463f-8722-1606cab02a66)

### Falling
![Fallandrespawn-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/48909f98-7da6-4ad7-aa9c-80ee396d5efe)

## Music
The game is playing 'Terraria Eerie - by Scott Lloyd Shelly & Re-Logic' on loop throughout the whole game (reference below)

## Conclusions
The game acts as a good proof of concept for a potentially engaging arcade came. It is made in 3D, has wonky restricted movement and inputs, has a simple objective but is hard to beat. Several improvements can be made for the future of the project:
1. More levels and longer levels using checkpoints
2. More traps/structures/decorations
3. Endless mode
4. Potential AI enemy
5. Buffs/De-buffs
6. Keeping track of progress and high-scores
7. Sound design for traps and interactions
8. Etc.

As we can see it can be improved in variety of ways, however, it contains main concepts and thematic intended for the game, which is what matters most. Overall considering my availability during this busy final semester of my bachelor studies I am happy with what I have ended up with. I put in the thought and work for this project and I am satisfied with its results. 

## Used materials:
### Music:
* 'Terraria Music - Eerie' by Scott Lloyd Shelly & Re-Logic - https://www.youtube.com/watch?v=R2Hs-v5XEFQ. 
Please support the creators by buying their music through https://re-logic.bandcamp.com/album/terraria-soundtrack or https://store.steampowered.com/app/409210/Terraria_Official_Soundtrack/
### Prefabs:
1.  Lava background -  [https://assetstore.unity.com/packages/vfx/shaders/lava-flowing-shader-33635](https://assetstore.unity.com/packages/vfx/shaders/lava-flowing-shader-33635)
2.  Flamethrower flame -  [https://assetstore.unity.com/packages/vfx/particles/vfx-magical-flames-293962](https://assetstore.unity.com/packages/vfx/particles/vfx-magical-flames-293962)
3.  Player death VFX -  [https://assetstore.unity.com/packages/vfx/particles/fire-explosions/comic-explosion-effect-317348](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/comic-explosion-effect-317348)
4.  Various prefabs -  [https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-low-poly-toon-battle-arena-tower-defense-pack-109791](https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-low-poly-toon-battle-arena-tower-defense-pack-109791)
5.  Various prefabs - [https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-free-dungeon-pack-191979](https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-free-dungeon-pack-191979)
6.  Various prefabs -  [https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692](https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692)
7.  Various prefabs -  [https://assetstore.unity.com/packages/3d/props/3d-low-poly-chest-240360](https://assetstore.unity.com/packages/3d/props/3d-low-poly-chest-240360)
8.  Intro Screen and Finish VFX -  [https://assetstore.unity.com/packages/vfx/particles/fire-explosions/low-poly-fire-244190](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/low-poly-fire-244190)
9.  Materials for everything -  [https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943](https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943)








