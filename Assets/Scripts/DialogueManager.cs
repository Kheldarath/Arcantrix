using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject SpeechBox;
    [SerializeField] GameObject NameBox;

    public GameObject DialogueBox;
    public GameObject NPCNameBox;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBox = SpeechBox;
        NPCNameBox = NameBox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
