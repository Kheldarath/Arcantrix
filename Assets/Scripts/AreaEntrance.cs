using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
   [SerializeField] string entranceFrom;

    Player player;
    UIController controller;
    UIFade uiFade;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        controller = FindObjectOfType<UIController>();
        uiFade = controller.GetComponent<UIFade>();
        
        if(player.lastArea == entranceFrom)
        {
            player.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        uiFade.FadeFromBlack();
    }


}
