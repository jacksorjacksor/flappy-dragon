# flappy-dragon

Entry for [Arcade Jam](https://thearcadevaults.org.uk/arcade-jam)

## BRIEF

The game will serve as a simulation of an arcade redemption game (a game that vends tickets)

-	Tickets given for progress (/distance)

Redemption games are typically very short and have high replayability. A single play of the game should take no more than 60 seconds

-	Timed (30 second?) flight.
-	Further you fly uninterrupted the faster you go

The controls should be very simplistic. The player should have to perform no more that one input at a time. The controls can take any form (button, wheel, dial, lever, touch screen, cranks, control sticks etc) but they should be able to be simulated on a mouse and keyboard or controller

-	Up, Down, Fireball + Option UI

The game should have no more than two mechanics

-	Movement up and down

-	Fireballs

The game should be designed for immediate and constant positive gratification. There are no losers

-	Always going forward, never game over, just lower progress

Visualise the game more as a short, guided gameplay experience rather than a game. It’s akin to designing a roller coaster
Redemption games are most similar to mobile games in their design. However, redemption games do not focus on long term player recapture (levelling up, inter-stage upgrades, timed rewards etc) they instead focus on keeping the player coining up for as long as possible
There should be a superbonus/jackpot mechanic which rewards highly skilled players. This should only be winnable roughly 10% of the time and should be controlled with difficulty (not compensated control). A player should feel like winning is always within reach

-	Bonus based on uninterrupted play time (e.g. 15 seconds uninterrupted flight = 2x tickets)

## Technical Specifications

The whole game will serve as a simulation of an arcade ticket game

-	See “Gameplay Loop”

The game should have a credit system, whereby the game can only start once ‘credits’ have been added. (push a button to add a credit, push a button to start the game)

-	UI controls to emulate/replicate

The game should have an options menu that can be accessed at any time during play/ idle and will contain game settings. Upon exiting this options menu, the game should return to its idle screen. 

-	UI controls -> always go back to IDLE screen

The options menu should contain variables to allow for the tuning of a game to a sites demographic (not a standard video game options menu)

-	…Unsure what this means?

The game should have an attract sequence of no more than 60 seconds which teases the gameplay and advertises it to bystanders. The attract sequence should begin and end with the games idle/ start screen and should only trigger when the game is not in use

-	Demo plays (demo)

One play of the game should last no more than 60 seconds

-	See “Brief”

The game should offer ‘tickets’ after every play. The amount of tickets should be a variable setting in the options menu

-	Tickets based on distance covered

The game should be recording the following statistics, these statistics should be displayed in the options menu:

-	The total time the game has been running for
-	The total number of ‘credits’ consumed
-	The total number of plays. This number should only increment on a completed game cycle
-	The average game time
-	The total number of ‘tickets’ paid out alongside the lowest and highest values

The game should be simplistic, easily understood, and require no tutorial in order for a novice player to understand how to play and how to win

-	Up, Down, Fireball buttons should show

The games inputs can be analogue or digital and can take any form, although they should be able to be simulated using a controller or mouse and keyboard

