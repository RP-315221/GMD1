# GMD1 - Gates of Hell - Milestone 2
## Introduction
For this milestone I put focus on implementing trap and other interactable object prefabs and their logic with the player interactions. This will help me greatly when building levels for my game :)
## List of stuff done:
1. Game Manager for detecting player collision with traps
2. Sawmill trap
3. Swinging blade trap
4. Spike trap
5. Arrow turret trap
6. Flamethrower trap
7. Level gates and pressure plate
8. Adjusted textures of my eyeball character, looks more menacing now ;)
## Game Manager - detects player death
Before starting off with building my traps I had to implement logic for player death. To do this, I created a new layer that I could assign objects to called 'Death'. I then created an empty game object called 'GameManager' and programmed it to detect collision between any objects marked with 'Death' layer and the player object. 

![image](https://github.com/user-attachments/assets/1a4be627-6145-4df5-a489-5293036b7351)

As you may notice from the code, once the collision is detected the player object is immediately destroyed and replaced with a skull explosion VFX at the same position. Here's how it looks like in action:

![PlayerDie-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/f14ef5e8-b5d2-4903-afc8-18f39d9dfa1f)

## Sawmill trap
The first trap I made was the sawmill. This trap aims to cover multiple grid tiles the player could traverse through and as all the other traps requires pitch perfect timing to beat. The trap itself was made out of two separate 3D prefabs, first being of course the sawblade, and the other marks the pathway of the saw.  

![image](https://github.com/user-attachments/assets/22a0cd90-4451-4a17-96ce-3701cc869b11)

The saw blade is marked with the 'Death' layer and has a mesh collider that collides with the player object. I added scripted behaviour for the saw to rotate and move  side to side and placed it in the middle of the pathway. I also made sure to include a delay for the movement to start so the traps are not in sync. 

![image](https://github.com/user-attachments/assets/5552852d-8068-45c6-bb28-fe63f969f921)

Finally I added custom textures for both parts of the trap and saved it as a prefab. Here is how it looks like in action:

![SawTrapWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/23de7115-e52f-4d9a-8c66-3b368c096845)

## Swinging blade trap
The second trap I made was the blade swing. Just like the saw its meant to cover multiple grid tiles, if not the whole grid width, however there's 1 difference between them. Unlike the sawmill, passing through the middle of the swinging blade is practically impossible, so the player is forced to take the route of either side of the trap. The trap itself was made out of 3 prefabs by someone else. 

![image](https://github.com/user-attachments/assets/3e589c8c-f00d-425c-97c7-cc19768d0090)

For the pillars, I threw out the mesh collider and replaced it with a much more efficient box collider and marked them as 'Object' layer so the player can bump into them. The blade came with a custom animation for its swinging, which I went ahead and adjusted the speed to fit the gameplay loop. Finally, I added custom textures for both parts of the trap and saved it as a prefab. Here is how it looks like in action:

![SwingingBladeWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/f8656ca0-b3a9-46bb-9704-d4878c78d73a)

## Spike trap
The third trap I made was spikes. The spike traps are meant to cover a single grid tile at a time. Getting through them requires patience and timing. The trap came as a prefab, which like all the others I have modified to fit my needs. 

![image](https://github.com/user-attachments/assets/45091a57-d033-4788-9f77-694cf91c94db)

First I replaced the mesh collider of the spikes with a box collider and marked them with 'Death' layer. Then I changed up the scripted behaviour of the trap, adjusting the speed of them and adding a delay to desync the traps. 

![image](https://github.com/user-attachments/assets/9dedf777-3c04-4a1d-81ea-d713029d3566)

Finally, I added custom textures for both parts of the trap and saved it as a prefab. Here is how it looks like in action:

![FloorSpikeswork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/aaca4706-b29b-4ea4-8f0b-2dc2bb21d768)

To make it more interesting I made another variant of them - wall spikes.

![WallSpikesWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/40ec1a1f-a1a5-49fc-b665-4c2d6eb04794)

## Arrow turret trap
The fourth trap I made was a rotating arrow turret. This one required a bit more work than the last 2 traps. Its purpose is to dynamically cut off passage ways for the player, forcing them to be more aware of their positioning and timing. The trap was made using 3 different prefabs:
1. Arrow prefab
2. Turret holes prefab
3. Pillar prefab

![image](https://github.com/user-attachments/assets/93a413e2-19b6-4f22-b7fe-0e4e85ca2062)

First thing I did was scripted the turret holes prefab to shoot arrows in the direction they are facing. 

![image](https://github.com/user-attachments/assets/103a8282-8263-4973-94eb-4e2f49604392)

To ensure arrows realistically stick to surfaces I adjusted their collider to be a bit shorter than the arrow tip and scripted the arrows to stop, and self destruct once collision with an 'Object' layer is detected. I added another collider at the tip of the arrow, right in front of the first one. This is meant for detecting collision with the player model. Lastly I attached the 'Death' layer to the arrow, so whenever it passes by the player, the player dies. 

![image](https://github.com/user-attachments/assets/9aeca24a-b915-4938-aabd-f016185d4fa7)

I then needed a body for the turret itself. Since I wanted it to rotate I also wanted to make sure its somewhat symmetrical. For that purpose I chose a brick pillar. I attached the trap to the pillar and scripted it to rotate every 3 seconds with a delay before start so that the shooting and rotating occurs at different times. Finally, I added custom textures for all 3 parts of the trap and saved it as a prefab. Here is how it looks like in action:

![ArrowTrapWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/c744bbd6-9086-4dba-bf55-0126fa7c528c)

## Flamethrower trap
The fifth trap I made was a rotating flamethrower. Its purpose is similar to the arrow turret, however unlike the arrow turret, you cant exactly pass the grid tile the turret is facing, until its rotated to the other side. The flamethrower trap was made using 3 prefabs too:
1. Fire VFX
2. Wine glass
3. Steel pillar

![image](https://github.com/user-attachments/assets/fb2c6639-0889-432b-baba-efbd83acd575)

I started my process by merging the pillar with the wine glass into 1 object. Then I adjusted the wineglass collider to extend way out to the side of the pillar and added the 'Death' layer to it. 

![image](https://github.com/user-attachments/assets/7b3c900c-afe9-42bf-80f2-2f957c86569c)

As you can see I marked the length of this collider by attaching a fire VFX and adjusting its length to fit the box collider. To finish off the trap behaviour I scripted the pillar to constantly rotate on the y axis. Finally, I added custom textures for both 3D models of the trap and saved it as a prefab. Here is how it looks like in action:

![FlamethrowerWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/b96baecc-4ff9-44d6-8130-06f7386004eb)

## Gates
To create a more interesting gameplay loop than just avoiding traps and traversing through a level I added gates and a pressure plate to open them. Though I am not exactly sure how I might use them in the levels, should you just step on the plate to open them or do you need to first collect something to unlock them, I made them regardless. The gates consist of 2 prefabs:
1. Physical gates
2. Pressure plate

![image](https://github.com/user-attachments/assets/32d41d4a-ad2a-4526-8725-66a15f3f847b)

I added scripted behaviour to the pressure plate. If the player steps on it, it lowers the gates for 10 seconds and then puts them back up. 

![image](https://github.com/user-attachments/assets/a02f92a8-dccb-4a9e-8ea7-d63249fb9d6f)

As for the gates, I adjusted the colliders. The main part is marked with 'Object' layer so the player can bump into the gates. However, I also attached an empty game object with another collider located at the top of the gates, marked with 'Death'. This is meant to punish the player if they are standing of the tiles of the lowered gate or if they are taking too long to pass and by some mistake end up timing their traversal through the gates at the last second. 

![GatesKill-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/947e598d-a752-42da-9030-990d215269c8)

Finally, I added custom textures for both 3D models of the trap and saved it as a prefab. Here is how it looks like in action:

![GatesWork-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/805e470c-2047-4a58-80eb-ccb13170f42f)

## Whats next?
Now that I have the trap prefabs set up and ready for usage, my next step is to look out for prefabs I could use to build and decorate my level, perhaps making a few myself and move on to level construction. Here's the progress in terms of milestones:
1.  Player Model + Movement - ***done***
2.  Traps and their logic - ***done***
3.  Level building - ***next***
4.  UI & Game Logic

## Prefab Links:
The following list is of links to the Unity Asset store packages which I have used for creating my traps :)
1. https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692
2. https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-free-dungeon-pack-191979
3. https://assetstore.unity.com/packages/3d/environments/dungeons/dungeon-low-poly-toon-battle-arena-tower-defense-pack-109791
4. https://assetstore.unity.com/packages/vfx/particles/fire-explosions/comic-explosion-effect-317348
5. https://assetstore.unity.com/packages/vfx/particles/vfx-magical-flames-293962
