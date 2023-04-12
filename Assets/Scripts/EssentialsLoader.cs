using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    [SerializeField] GameObject UIScreen;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (UIController.instance == null)
        {
            Instantiate(UIScreen);
        }       

        if (Player.instance == null)
        {
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
;