# GMD1 - Gates of Hell - Milestone 4
## Introduction
For this milestone I put focus on the games UI, music and finishing touches of the logic. Here is the list of stuff done for this final milestone:
1. Created UI elements and placed them in every scene
2. Implemented end credits scene
3. Implemented SceneHandler for transferring between scenes
4. Implemented level finish
5. Implemented player falling
6. Implemented player respawn
7. Added background soundtrack

## UI
### Creating elements - Canva
Since this is an arcade game I wanted to introduce UI elements that are within the theme, pixelated and informative. Considering that I don't really have a menu to interact with I decided to create the UI elements using the 'Canva' online tool. Here I made different variations of text and text boxes giving the player instructions through out the game.

![image](https://github.com/user-attachments/assets/a0575e02-99af-4ff9-b62f-ba80e8bbf43e)

### Element placement - unity
I downloaded the elements as separate transparent .png files. Then I applied them as Raw Image UI elements through the Unity Canvas tool, adjusting their positioning and size on the screen to fit my needs :)

![image](https://github.com/user-attachments/assets/196c8584-ae6b-4519-9a97-9facc14f6462)

![image](https://github.com/user-attachments/assets/94e6783f-9d9e-491f-9b35-db1e2696d02b)

![image](https://github.com/user-attachments/assets/8ec12c48-88ed-4c8e-ba18-846ccf3a9454)


## End Credits scene
I realized my game did not have any end to it, so I quickly created a simple End Credit scene where I placed some text referring to me as the game designer and the music creators of the soundtrack I used. I then placed a fire VFX in the background to go with the Hellish theme.

![image](https://github.com/user-attachments/assets/c63739a7-ab0a-4168-a400-b64dd9c5b192)

## SceneHandler
Now that I had multiple scenes I needed logic to transfer between them. For that purpose I have implemented the SceneHandler. This object is used for transfering between scenes once the player finishes the level. It does so by calling the LoadScene and LoadNextScene methods.

![image](https://github.com/user-attachments/assets/38c85684-550e-4f25-813c-6e3de238709c)

## Level Finish
Now that I had the scene manager ready for use, I could implement logic of the player finishing the level. To mark the end of the level I used a fireplace prefab from my RollABall game. I added a box collider with a trigger to it so I could show a UI element for the player that would allow them to go to the next level. 

![image](https://github.com/user-attachments/assets/9a0045aa-7392-4cab-b573-680c161d823b)

Creating code that would dynamically enable and disable UI elements based on which scene we are in was difficult for me and did not work, so I resorted to making the scene manager local to the scene. For that reason I handled the UI through it as well, which resulted in a bit of a spaghetti code. Once player collides with the finish object, it calls the scene handler to take care of the player transferring scenes. 

![image](https://github.com/user-attachments/assets/1184f11c-1196-4c0f-aafb-0ac59963dee5)

The SceneHandler does a couple of things once called for this. First it enables UI elements for passing the level that are referenced to it through the inspector. Then it awaits input from the user.

![image](https://github.com/user-attachments/assets/e1d5b460-2437-45c0-9b5b-995892ef75c3)

During the next update call it process the player input. If the player moves, the scene handler hides the panel and starts a countdown for the next time the player can trigger the same interaction. If the player presses the 'B' button we are put back into starting screen and if 'A' or 'X' is pressed we go to the next screen.

![image](https://github.com/user-attachments/assets/a1992d8a-7d30-47f7-a19d-cb0cc2ea4cfd)

Here's how it looks in action :)

![SwappingScenes-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/fe4791e0-5fee-439e-85a2-c959d8338871)

## Player Fall
Since our levels have boundaries and pitfalls I had to force the player to die if they step out of the pathways. This was easier said then done, making them just instantly explode sounded boring. But since we are animating the player floating through a script I could not enable gravity to them. Therefore I had to create a workaround. I added the LevelBase layer to the pathways of our level and using the GameManager shot a ray-cast down from the player. If the ray-cast does not detect the level base, we start a grace period to avoid any accidental calls.

![image](https://github.com/user-attachments/assets/a4d48cdf-2578-444c-952c-9c0745814bcf)

The GracePeriodFallCheck starts a timer during which the player can get back on land, if they dont we force their death.

![image](https://github.com/user-attachments/assets/cd928c62-5c54-4179-b42b-2a9cd2fa403b)

To make their death different than dying from a trap I added a seperate method that disables all player movement, simulates them falling for a second or two and destroys them :)

![image](https://github.com/user-attachments/assets/beb150e1-94de-4f76-b3bb-96d3a76cee51)

Here is the player fall in action:

![Falling-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/79be5cb3-282d-4461-a775-edec3aecd46f)

## Player Respawn
Since our player will be dying a lot in this game we obviously need to implement respawns. For this purpose I went back to the GameManager. We check if the player is dead in the update method. If they are, a death panel appears. The player than can either respawn by pressing the button 'Y' or go back to start screen by pressing 'B'. 

![image](https://github.com/user-attachments/assets/311734c0-4a37-4477-bb48-de80e07b0fbf)

If the player chooses to respawn, we then make a clone of our player object and register them for both the camera and as a new ref. object for the game manager

![image](https://github.com/user-attachments/assets/bfbfee5a-2206-40d5-9656-6b27b377bd67)

Here's how everything looks like in action :)

![Respawning-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/7b8a425d-15ab-4e2a-9dc6-6fe1142302b3)

## Background soundtrack
As a final touch to the game I have added a soundtrack to it. During the planning of the game I was very sure that I wanted to use a specific track from Terraria. I chose Eerie - by Scott Lloyd Shelly & Re-Logic (link at the end of the doc, also referenced in End Credits and Github Repository ReadMe.md file). 

![Terraria 'Eerie' - by Scott Lloyd Shelly & Re-Logic](https://www.youtube.com/watch?v=3CM1_Ji6fJ8)

This track captures the feeling of hell like nothing else for me. I have grown up playing Terraria with my cousins and having this music in my game sets the perfect nostalgic mood :) 

I put the music in the game by creating a music manager that takes the track and loops it. I also made sure to implement the manager as a singleton so it can seamlessly loop no matter if were switching scenes or not.

![image](https://github.com/user-attachments/assets/a0800561-4b71-4f0d-943e-0db51ea62b24)

## Used material:
'Terraria Music - Eerie' by Scott Lloyd Shelly & Re-Logic - https://www.youtube.com/watch?v=R2Hs-v5XEFQ. 
Please support the creators by buying their music through https://re-logic.bandcamp.com/album/terraria-soundtrack or https://store.steampowered.com/app/409210/Terraria_Official_Soundtrack/








