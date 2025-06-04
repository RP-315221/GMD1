# GMD1 - Gates of Hell - Milestone 3
## Introduction
For this milestone I put focus on building the levels for my game. The following list provides an overview of my workflow:
1. Gathered and edited prefabs for building the level
2. Planned the levels
3. Built 2 levels and an intro scene

## Prefabs
In order to build my levels I first needed to gather or create various prefabs to be used. Doing this beforehand ensured that I would have a solid understanding of objects available to me for when planning the layouts. I split my prefabs into 4 types so I can adjust the player behaviour to them.
1. Traps - already covered
2. Structures - larger scale objects the player can bump into
3. Decorations - smaller scale objects that serve the purpose of improving the visuals of the levels
4. Tiles - grid tiles representing the pathway the player can take

### Structures
I have gathered structures for the purpose of helping me design the layout of the level, cutting off certain pathways and allowing stalling strategies, while also improving the visual aesthetics of the level. Since I want to allow the player to bump into them I had to ensure the objects had colliders on them. Some came with Mesh colliders, which are computationally expensive, others had no colliders at all, so I manually place box colliders for all of them.

![image](https://github.com/user-attachments/assets/6f829739-6f8f-42f0-955f-e78e68e5c388)

### Decorations
In order to improve the visual looks of my levels I also gathered a bunch of decorations, some of which I have combined to look nicer. I removed any colliders to them so they do not obstruct the players path and adjusted their size to fit my needs.

![image](https://github.com/user-attachments/assets/40222d00-81f9-41bc-abd1-8ed280a07996)

### Tiles
In order to structurally design the level layout I made variety of tile prefabs. I drew inspiration from earlier mentioned game 'QuestKeeper' where the player traverses through a tile-set level. It made it easier to show the possible path of the player while also maintaining a nice look of the level.

![image](https://github.com/user-attachments/assets/a3407e84-acec-4c96-beba-8feb0583b9c3)

### Textures
To keep the hellish vibe of the game I swapped out textures for practically all of my prefabs to the set I used for creating traps. This blends the whole environment nicely and very clearly indicates that we are indeed in hell.

![Desktop2025 06 04-20 25 20 08 DVR-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/12bf77e4-3f8f-4f79-ba30-94723717a93c)

## Level Plans
Having in mind the traps and prefabs available to me I have planned the level layouts on a piece of paper. Using a checkered paper sheet for this task made sense, because I could directly map between the unity tile grid and the checkered grid on my paper to indicate the intended size for various sections of the levels. This made building them way easier in the long run. Down below we can see images of the level plans + the agenda.

![image](https://github.com/user-attachments/assets/a7b79e3f-acc1-4ae2-9a73-541e4fca8125)
![image](https://github.com/user-attachments/assets/9f15371f-93b8-423b-8474-3b03b355c2cc)

## Level building
### Title Screen
Before building the levels I wanted to make a Title Screen scene for my game. In order to capture the essential thematic of it I have created a simple box room in which we have our player character, the gates we will be opening during the gameplay, some decorations and fire in the background that screams 'Hell'.

![Uploading StartScreenCut-ezgif.com-video-to-gif-converter.gif…]()

### Level 1
Level 1 is meant to be easier on the player as it starts our journey through the game. Here we see the traps we will encounter in further levels for the first time. Traversing through level 1 becomes increasingly more difficult as we mix in different traps and increase the quantity of them and create thinner pathways for the player to go through. Moreover, we have 2 gates separating the main parts of the level with pressure plates that are easier to reach. 

![Level1cut-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/4f5e29e3-19aa-43a4-a657-5495490bb6d8)

### Level 2
Level 2 is where we crank up the difficulty of the game. Here we have more complicated pathways for the player to take. Passing it requires way more focus, better strategy and pitch perfect timing. Moreover, certain sections of it have more than a few ways of getting through. This level acts as demonstration of how difficult the game can get and how we foster players to take different pathways for completing the level. Players will die and learn here a lot, giving the game that retro arcade feel. 

![Level2cut-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/73adc0c1-7f2c-4b94-b84a-71f5492498da)

## Whats next?
Now that I have level scenes prepared, I need to implement UI for the game and scene management. Moreover, there are still a few finishing touches left, such as logic for falling off the map, respawning the player and including a soundtrack to play during our game. Here's our progress in terms of milestones:
1.  Player Model + Movement - ***done***
2.  Traps and their logic - ***done***
3.  Level building - ***done***
4.  UI & Game Logic + finishing touches - ***next***

## Prefab Links:
The following list is of links to the Unity Asset store packages which I have used for creating my levels :)
1. Lava background - https://assetstore.unity.com/packages/vfx/shaders/lava-flowing-shader-33635
2. Flamethrower flame - https://assetstore.unity.com/packages/vfx/particles/vfx-magical-flames-293962
3. Player death VFX - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/comic-explosion-effect-317348
4. Prefabs and traps - https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-low-poly-toon-battle-arena-tower-defense-pack-109791
5. Prefabs https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-free-dungeon-pack-191979
6. Prefabs - https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692
7. Prefabs - https://assetstore.unity.com/packages/3d/props/3d-low-poly-chest-240360
8. Intro Screen and Finish VFX - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/low-poly-fire-244190
9. Materials for everything - https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943
