using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string areaToLoad; //Next scene to load
    [SerializeField] string exitName;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        player.lastArea = exitName;
        SceneManager.LoadScene(areaToLoad);
    }

}
