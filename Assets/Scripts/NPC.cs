using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    /// <summary>
    /// Primarily for Dialogue attributed to NPC, but may include Behaviour calls
    /// </summary>
    [SerializeField] string NPCName;
    [SerializeField] GameObject NPCNameBox;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] string[] scriptLines;

    UIController ui;

    Text nameBox;
    Text speechBox;
    PlayerMovement player;
    DialogueManager dialogueManager;

    int currentLine = 0;
    bool saidHello = false;
    bool playerHere = false;

    private void Awake()
    {
        ui = FindObjectOfType<UIController>();
        
    }

    private void Start()
    {
       player = FindObjectOfType<PlayerMovement>();
       dialogueManager = FindObjectOfType<DialogueManager>();
       DialogueBox = dialogueManager.DialogueBox;
       NPCNameBox = dialogueManager.NPCNameBox;
    }
        
    private void OnTriggerEnter2D(Collider2D coll)
    {       

        if (coll.gameObject.tag == "Player")
        {
            bool playerHere = true;            
        }

        
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (currentLine > 0)
            {
                currentLine = 0;
            }

            playerHere = false;
            player.itemActivate = false;
        }

        DialogueBox.SetActive(false);
    }

    void greeting()
    {
        if (saidHello)
        {
            if (player.itemActivate)
            {
                currentLine++;
                player.itemActivate = false;
                speechBox = DialogueBox.GetComponentInChildren<Text>();
                speechBox.text = scriptLines[currentLine];
            }
        }
        else
        {
            currentLine = 0;
            speechBox.text = scriptLines[currentLine];
            saidHello = true;
        }
    }

    void GetUI()
    {
        DialogueBox.SetActive(true);

        nameBox = NPCNameBox.GetComponent<Text>();
        speechBox = DialogueBox.GetComponent<Text>();
        
        nameBox.text = NPCName;
    }

    private void Update()
    {
        if (playerHere)
        {
            GetUI();
            greeting();
        }
    }
}
