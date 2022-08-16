using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] string NPCName;
    [SerializeField] GameObject NPCNameBox;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] string[] scriptLines;

    Text nameBox;
    Text speechBox;

    bool saidHello = false;

    private void Awake()
    {
        nameBox = NPCNameBox.GetComponentInChildren<Text>();
        speechBox = DialogueBox.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        //TODO instruct to wait for player to press activate on npc
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            //TODO
        }
    }

    void greeting()
    {
        
    }
    
}
