# Game Name Here!(Jump Mario)
### developed by CSE-3902-Meta-Knight
_________
**CONTACT INFO**
 
 
    Name           Email                                 Phone#
    Alex           clayton.228@buckeyemail.osu.edu       (815)713 9119
    Alex           contreras.84@buckeyemail.osu.edu      (614)802 7074
    Jared          israel.93@buckeyemail.osu.edu         (206)755 4675
    Leon           cai.855@buckeyemail.osu.edu           (614)849 5255
    Owen           tishenkel.4@buckeyemail.osu.edu
    Owen           huston.213@buckeyemail.osu.edu
_____
**PROGRAM DESCRIPTION**

As of Sprint 2, this program implements Link, link movement, primitive attacking and item placement, enemy movement, cyclable enemies, cyclable blocks, cyclable, a quit button and a partial reset button.
_________

**MOTIVATION**

Other than older people looking for nostalgia and students trying to see the roots of modern gaming, who wants to play old platformers/RPGs like Super Mario Bros or Zelda anymore? Gaming has undoubtedly evolved past the simple controls, easy enemies and basic gameplay loops of that era, but with small changes to level design, enemy design, and gameplay mechanics, the model can be much more appealing to a modern audience. That is what this game seeks to do, at its heart it is a Mario clone, but using a series of small, achievable changes inspired by successful modern platformers, it can become a more viable product that will make this semester a more powerful learning experience and a better resume builder.

**INSPIRATIONS**

Jump King, Celeste and Leap Day

**PLANNING**

SPRINT 2

Set up git repository:    Alex Clayton

Set up planning documents:      Jared Israel

Implement keyboard input:    Alex Contreras,       Alex Clayton,    Owen Tishenkel

Implement command and controllers:      Alex Contreras,           Alex Clayton,         Owen Tishenkel

Create interfaces:              Alex Clayton,        Leon Cai

Create Item classes: Jared Israel,  Owen Huston

Create SpriteFactory: Alex Clayton,  Alex Contreras,  Owen Huston

Create enemy classes: Alex Clayton,  Owen Huston

Create item classes:  Jared Israel,  Owen Huston

Create block classes:  Alex Contreras, Owen Huston

Create Player class and concrete player states:  Jared Israel,  Owen Tishenkel, Alex Contreras

Player state transitions: Leon Cai,  Jared Israel,  Owen Huston

Fully planning board is in https://trello.com/b/7FCwThdy/sprint-12

Discord: https://discord.gg/6rHXSp9hYV (we used this for planning so please check it out)

_____

**ZOOM MEETING**

Meeting1 9/13/21       https://osu.zoom.us/rec/play/aMc50H_YmbxinDd-saoUFqyj4CqbS6AcwKteE9o-dHUz0gTfZ8QloFrWEkU1QFjmhltVUWHiObJtnUK1.6sEX2RksvbyEzEwg?autoplay=true&startTime=1631584920000

In this initial meeting, we first focused on finalizing some of the tasks that we had not completed for sprint 1 yet. First, we set up a trello board for the group, adding columns that represented steps in the Agile development cycle, and adding everyone to it. Then, we finished setting up the GitHub repository and pushing one team member's sprint 0 code as a code base, and got everyone connected with individual branches for working on sprint 2. We also briefly discussed how we would go about meeting regularly, noting how almost all team members are able to do a brief in-person scrum meeting after class, and we would also most likely have a weekly, more long form zoom meeting, especially at the start of sprints.
 Now that the tasks for sprint 1 were complete and everyone had the capability to begin working, we went over the requirements and tasks for sprint 2 and began to fill out cards on the trello board. We then began to discuss what tasks were most important or could be grouped together due to similarities, and began to add labels for the highest priority tasks that could block other tasks from happening. After all the tasks were on the board, we began to assign teammates to all of the tasks, distributing tasks evenly and trying to work with people's strengths to maximize efficiency. We tried to have two team members per task, so if a teammate was stuck or confused they would be able to reach out to their teammate for help. Another point of discussion was how we would go about code review, where we decided that having a rotation system so nobody is stuck looking at one members code consistently would be a good idea to avoid gaps in knowledge that may lead to bugs if one member consistently overlooks something, a code review channel was also created in the team discord server. Before leaving, we decided on a few, higher priority tasks that should be done by our next scrum meeting on wednesday, and set their dates on the trello board. 
 
Edited by Jared Israel

Meeting 2 9/26/21      https://osu.zoom.us/rec/share/g0iwkYPg39U6XAN0S9Dv2aAW7fzdejsrcB8ChITCth40zSEdI5Mturw1jtDgKCXs.VI6rADvP_1V9aJWf?startTime=1632697347000


This meetings main goal was to get group members on the same page about newly implemented systems such as the players movement states and health state machine as well as how these systems would be combined with already present systems such as the sprite factory to work properly. First, Jared went over the new framework he created for the players movement states, which were implemented using a state pattern, then the health state machine, which was a simple script that used an enum for the players current health. The team discussed and reviewed this code, and brought up some potential issues and how these might be solved. In particular, how the team would connect this system with the partially complete sprite factory. We debated the sprite factory's responsibilities and if it should handle any drawing of sprites, and eventually decided that it would be best if the sprite factory was only responsible for creation, and link would keep track of its current sprite and update and draw it himself. This made sense to us as having the sprite factory be responsible for player and enemy sprites seemed bad for coupling and was more functionality it should be doing.
This led us into a discussion about a future game object system where we would have one game object manager that knew about all moving (and thus collision causing) sprites and would update and check collisions for those. We came to the conclusion that having an interface for a game object that one manager could then call update and draw on would be a good idea, and whenever a moving object initializes, we could have it add itself to the managers list. This also would in theory let us just call object managers update call in game0.cs’s update function rather than individual update calls for link, enemies, or blocks. 
	Lastly, we compared implementations for Jared and Leon of certain states for link and decided which parts of the code seemed best to use in our project wide solution. This brought up the point of improving our planning on tasks assigned to multiple people, as with this specific task, Leon and Jared did not plan well and ended up doing the whole task twice, rather than splitting up the work evenly. This caused there to be more work total and more work then deciding which implementation to use.


Edited by Jared Israel

Meeting3 9/29/21       https://osu.zoom.us/rec/share/LnFN7PrFzNrIOWJAr4JHaGgMGRH_X1hMO3NWFHOI7vQNP6XmJdxF4zs0n08KQhEA.hQ9CziPspd0r-raS

Our goal for this purpose was to meet together as a group and merge all of our separate code into the main Sprint 2 branch, to get all currently implemented functionality working together properly. This would allow us a more solid foundation to proceed with the remaining tasks of Sprint 2 and finish up, as we felt we were lagging behind in certain respects. 
	Initially, we began working through code together for the sprite factory, which had a bug in it, causing it to render broken sprites. By sharing screens, we could all collectively search for bugs and discuss what we thought was going wrong. After some searching, we discovered the code to get frames for animated sprites was based off the tutorial code, which assumed gapless sprite sheets, whereas our sprite sheet had gaps between frames that were causing bad frames to be rendered. This meant that our data sheet needed to be rewritten to account for the gaps. As a group, we rewrote one of the animated sprites with our solution and got it to work properly, then noted that a group member would have to rewrite the sprite sheet in the future. Once this was done, we then took a look at getting the now working sprite factory to give sprites to our link states. This took a considerable amount of coding as the states did not know the functionality of the sprite factory yet and thus we needed to code in certain solutions as a team. However, eventually, we got Link to display properly and his state to change as intended. 
	Next, we took a look at getting the link to move properly. As a group we coded the solution to create moving states for link, as only static states were present previously, and with some modifications to the keyboard controller and certain commands to the player, we were able to get horizontal movement working. At this point, we decided that we had reached a good stopping point, having gotten the sprite factory, player states, player movement, and keyboard controller/command system to work properly. The next steps were all four directions of player movement and reworking the data sheet so all sprites could be used with the player states. We left with our game rendering link like so.

Edited by Jared Israel
_________






______
**CREDITS**  
Sprites sheets taken from https://www.spriters-resource.com/nes/legendofzelda/

Link sprites and enemy sprites: http://www.zeldagalaxy.com/sprites-nes-loz/
