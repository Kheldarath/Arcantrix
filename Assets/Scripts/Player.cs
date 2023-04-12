using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public string lastArea;
    private Vector3 bottomLeftLimit, topRightLimit; //so we can keep the player in bounds

    void Start()
    {
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

    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void ClampPlayer(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(1f,1f,0f);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0f);        
    }
}
