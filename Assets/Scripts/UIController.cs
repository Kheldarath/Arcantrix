using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] GameObject uiFadeScreen;
    [SerializeField] GameObject dialogueManagerScreen;
    [SerializeField] GameObject uiCanvas;

    public UIFade uiFade;
    public DialogueManager dialogueManager;

    private void Start()
    {
        uiFade = GetComponent<UIFade>();
        dialogueManager = GetComponent<DialogueManager>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);

       
    }

}
