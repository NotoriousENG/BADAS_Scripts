using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/********************
 * DIALOGUE TRIGGER *
 ********************
 * A Dialogue Trigger can be anything, an NPC, a signpost, or even an in game event.
 * 
 * A Dialogue Trigger is responsible to activate based on some action in the game e.g. talking to an NPC
 * To handle talking to an NPC, we first attach this script to an NPC along with a dialogue file we write (e.g. .txt)
 */

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset TextFileAsset; // your imported text file for your NPC
    public bool TriggerWithButton;
    public GameObject optionalButtonIndicator;
    public Vector3 optionalIndicatorOffset = new Vector3 (0,0,0);
    private Queue<string> dialogue = new Queue<string>(); // stores the dialogue (Great Performance!)
    private float waitTime = 0.5f; // lag time for advancing dialogue so you can actually read it
    private float nextTime = 0f; // used with waitTime to create a timer system
    private bool dialogueTiggered;
    private GameObject indicator;

    // public bool useCollision; // unused for now

    private void Start() 
    {
        if (optionalButtonIndicator != null)
        {
            indicator =  GameObject.Instantiate(optionalButtonIndicator);
            indicator.transform.parent = transform;
            indicator.transform.localPosition = optionalIndicatorOffset;
            indicator.SetActive(false);
        }
    }
    /* Called when you want to start dialogue */
    void TriggerDialogue()
    {
        ReadTextFile(); // loads in the text file
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // Accesses Dialogue Manager and Starts Dialogue
    }

    /* loads in your text file */
    private void ReadTextFile()
    {
        string txt = TextFileAsset.text;

        string[] lines = txt.Split(System.Environment.NewLine.ToCharArray()); // Split dialogue lines by newline

        foreach (string line in lines) // for every line of dialogue
        {
            if (!string.IsNullOrEmpty(line) )// ignore empty lines of dialogue
            {
                if (line.StartsWith("[")) // e.g [NAME=Michael] Hello, my name is Michael
                {
                    string special = line.Substring(0, line.IndexOf(']') + 1); // special = [NAME=Michael]
                    string curr = line.Substring(line.IndexOf(']') + 1); // curr = Hello, ...
                    dialogue.Enqueue(special); // adds to the dialogue to be printed
                    dialogue.Enqueue(curr);
                }
                else
                {
                    dialogue.Enqueue(line); // adds to the dialogue to be printed
                }
            }
        }
        dialogue.Enqueue("EndQueue");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!TriggerWithButton)
            {
                TriggerDialogue();
            }
            // Debug.Log("Collision");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log(other.name);
        if (other.gameObject.tag == "Player" && Input.GetButton("Jump") && nextTime < Time.timeSinceLevelLoad)
        {
            if (!dialogueTiggered)
            {
                TriggerDialogue();
                dialogueTiggered = true;
                if (indicator != null && indicator.activeSelf == true)
                {
                    indicator.SetActive(false);
                }
            }
            nextTime = Time.timeSinceLevelLoad + waitTime;
            FindObjectOfType<DialogueManager>().AdvanceDialogue();
        }
        else if (other.gameObject.tag == "Player")
        {
            if (!dialogueTiggered)
            {
                // Debug.Log("Press Space");
                if (indicator != null && indicator.activeSelf == false)
                {
                    indicator.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            dialogueTiggered = false;

            if (indicator != null && indicator.activeSelf == true)
                {
                    indicator.SetActive(false);
                }
        }
    }
}
