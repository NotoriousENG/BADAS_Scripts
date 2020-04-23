# BADAS_Scripts
Free and open-source code for game development for all of you BADAS's out there!

# How to Download

## Simple (Good for individual scripts)
Click on the script you would like, right click on the raw button, press Save As
(You can also download everything as a Zip File)
Be careful some scripts depend on eachother, if something doesn't work, I recommend downloading everything as a zip file.

## Git (Good for fast updates on all scripts)
1) Install Git: https://git-scm.com/downloads
2) cd into directory using cmd or terminal
```sh
$ cd "PATH_TO_UNITY_PROJECT_FOLDER/Assets/Scripts"
```

3) Copy Git Clone URL
```sh
$ git clone https://github.com/NotoriousENG/BADAS_Scripts.git
```

### If you use git you can update anytime by
using git GUI or by running the following comands:
```sh
$ cd PATH_TO_UNITY_PROJECT_FOLDER/Assets/Scripts/BADAS_Scripts
$ git pull
```

# Tutorials
## PlayerAnimController
https://www.youtube.com/watch?v=CnN7L-5ygoc
## Dialogue System
https://www.youtube.com/watch?v=SuuO_qMiNCw&feature=youtu.be
## Weapon System
https://www.youtube.com/watch?v=ihBBz4PkKzw&list=PLqzDlUNiQomvrUTMh_PaGEC1z0rONWtDc
## Lite Weapon System
https://www.youtube.com/watch?v=2g5mTXn7Cic
## Enemy AI
https://www.youtube.com/watch?v=ihAw8O6dEu4&feature=youtu.be

# Usage
## PlayerAnimController
Attatch to player, handles inputs and setting animator properties. A replacement for the former Move2D script.
## Player[State]Behaviour
In the animator window, click on the state you have created and in the inspector add these scripts to the appropriate states. This implementation replaces the state machine and is simpler to create new states. e.g. In the animator Idle transitions to Walking when moveMagnitude > 0. PlayerWalkBehavior will then become active and the player will moved based off of the Input.GetAxis(...) values. https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s 
## How to keep your animator simple
Use a blend tree for directional movement, this way you won't have to draw transitions for every walking state for every direction. https://www.youtube.com/watch?v=32VXj5BB7wU 
## Dialogue Manager
Needs to be an object in a scene, I recommend adding it to an Empty in the Canvas and adding whatever you will use for your text box as child of this object and the text objects as children of it. Make sure to set the Texbox, etc. freezePlayerOnDialogue will set the animator to idle and disable movement until dialogue is finished.
## Dialogue Trigger
A Dialogue Trigger can be an NPC, a sign, an event, anything really. For right now we are using Trigger2D Collision to trigger dialogue. Add the Dialogue Trigger to your NPC (or etc.) and try loading in the sample dialogue or perhaps write your own.
## Writing Dialogue Files
Dialogue Files can be written with your favorite text editor. I used .txt but you can use any of these: https://docs.unity3d.com/Manual/class-TextAsset.html. I like to denote a new dialogue portion with an extra newline. Additionally, you can set the name for a line of dialogue by writing [NAME=TheNameYouWant] at the beginning of a line of text. This name will remain until you finish the dialogue or change it.
## Weapons and Projectiles
More Complicated, see tutorial video above.
## EnemyAI 
### Patrol
* Create a container (Empty gameObject) for the enemy, inside this container will be a gameObject (an enemy) with an animator, rigidbody2D (gravity set to zero, Z rotation locked), and a collider2D of some sort. 
* Create or add an animation then go to the animator window. 
* Add a state for Patrol, add the patrol behaviour of your choice (EnemyPatrolAreaBehaviour/ EnemyPatrolPathBehaviour).
* If using EnemyPatrolPathBehaviour, add an empty called "Paths" to your container and add new empties to create a path. To make this easier, you can add the DrawTransformLines script. To traverse the blue lines only, set isLoop to false. If is Loop is true, you will also traverse the red line (complete the loop).
### Chase
* Create a new animator state e.g. Chase
* add EnemyChaseBehaviour to the state
* to get colisions, add a new collider (not trigger)
* (NOTICE) there is no intelligent pathfinding, look into A* for this functionality if you think you need it: https://arongranberg.com/astar/ , https://www.youtube.com/watch?v=jvtFUfJ6CP8&t=908s
### Controller
* add to enemy gameObject
* set the respawnRange (how far away from the player before the enemy gives up)
* make sure the animator has a parameter called "distance" of type float
* set up transitions between your states
## 3D Package
* This package is aimed for more experienced developers who would like to kickstart 3d development
* There's not as much documentation for the scripts, but importing the package will leave you with a working scene with multiple features.
* includes 3D controls, running, jumping, attacking, simple camera system, combat system, moving platforms, a sample UI and more
