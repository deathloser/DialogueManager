using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    private class dialogueDisplay {
        public int id { get; set; }
        public string dialogueText { get; set; }
        public string audioClip { get; set; }
        public string eventName {get; set;}
        public string buttonText { get; set; }
    }
    public TextMeshProUGUI dialogueText;
    public TextAsset csvFile;
    public GameObject dialogueDisplayObject;
    public int currentRowCounter;
    List<string> dialogue = new List<string>();
    List<string> audioQueue = new List<string>();
    List<string> displayToggle = new List<string>();
    public bool dialogueActive = true;

    public void increaseDialogueCounter() {
        Debug.Log("increased counter to " + currentRowCounter);
        Debug.Log(dialogue.Count);
        if (currentRowCounter < dialogue.Count-1) {
            currentRowCounter += 1;
            dialogueText.text = dialogue[currentRowCounter];
            
        } else {
            Debug.Log("No more dialogue to display.");
            closeDialogueBox();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRowCounter = 1;
        dialogueDisplayObject = GameObject.Find("DialogueDisplay");
        dialogueText.text = "Hello";
        

        if (dialogueActive) {
            openDialogueBox();
        } 
        parseCsv();

        dialogueText.text = dialogue[currentRowCounter];
        
    }

    public void openDialogueBox() {
        dialogueDisplayObject.SetActive(true);
        dialogueActive = true;

    }

    public void closeDialogueBox() {
        dialogueDisplayObject.SetActive(false);
        dialogueActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private List<string> parseCsv() {
        string[] data = csvFile.text.Split('\n');
        foreach (string row in data) {
            // Debug.Log(row);
            string[] elements = row.Split(',');
            // Debug.Log(elements[0]);
            dialogue.Add(elements[0]);
            audioQueue.Add(elements[1]);
            displayToggle.Add(elements[2]);
        }
        return dialogue;
    }

    void readDialogueArray(List<string> dialogue) {
        // Debug.Log(dialogue);
        foreach(string sentence in dialogue) {
            Debug.Log(sentence);
        }

    }
}
