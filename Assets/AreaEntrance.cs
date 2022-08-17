using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
   [SerializeField] string entranceFrom;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        
        if(player.lastArea == entranceFrom)
        {
            player.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }
    }


}
