using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player _instance;
    public string lastArea;


    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        
    }
}
