# BADAS_Scripts
Free and open-source code for game development for all of you BADAS's out there!

# How to Download

## Simple (Good for individual scripts)
Click on the script you would like, right click on the raw button, press Save As

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

### If you use git you can update anytime by calling
```sh
$ cd PATH_TO_UNITY_PROJECT_FOLDER/Assets/Scripts/BADAS_Scripts
$ git pull
```

<<<<<<< HEAD
=======
# Tutorials
## PlayerAnimController
https://www.youtube.com/watch?v=CnN7L-5ygoc
## Dialogue System
https://www.youtube.com/watch?v=SuuO_qMiNCw&feature=youtu.be

>>>>>>> b9942a87378eb7e2729c668dcb01141e4e970bcf
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

# Demos
## State Controller Using the Unity Animator
https://www.youtube.com/watch?v=5trXpi3am-U
## Simple Dialogue
https://youtu.be/G9jFkq2zQUM
