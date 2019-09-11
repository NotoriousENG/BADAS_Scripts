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

# Usage
## Move2D
Needs to be attached to a Player Object In Unity. For best results use a dynamic rigidbody2d and set your boundaries to something big {(-9999,9999) , (-9999,9999)}.
## Dialogue Manager
Needs to be an object in a scene, I recommend adding it to an Empty in the Canvas and adding whatever you will use for your text box as child of this object and the text objects as children of it. Make sure to set the Texbox, etc.
## Dialogue Trigger
A Dialogue Trigger can be an NPC, a sign, an event, anything really. For right now we are using Trigger2D Collision to trigger dialogue. Add the Dialogue Trigger to your NPC (or etc.) and try loading in the sample dialogue or perhaps write your own.
## Writing Dialogue Files
Dialogue Files can be written with your favorite text editor. I used .txt but you can use any of these: https://docs.unity3d.com/Manual/class-TextAsset.html. I like to denote a new dialogue portion with an extra newline. Additionally, you can set the name for a line of dialogue by writing [NAME=TheNameYouWant] at the beginning of a line of text. This name will remain until you finish the dialogue or change it.

# Demos
## Simple Dialogue
https://youtu.be/G9jFkq2zQUM
