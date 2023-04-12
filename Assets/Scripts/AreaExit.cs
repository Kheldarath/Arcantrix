using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string areaToLoad; //Next scene to load
    [SerializeField] string exitName;
    [SerializeField] float loadTime;
    [SerializeField] bool ShouldLoadAfterFade =  false;

    Player player;
    UIController controller;
    UIFade uiFade;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        controller = FindObjectOfType<UIController>();
               
    }

    private void Update()
    {
       if(ShouldLoadAfterFade)
        {
            loadTime -= Time.deltaTime;
            if(loadTime < 0)
            {
                ShouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            controller.uiFade.FadeToBlack();

            PlayerMovement.instance.canMove = false;

            LoadNextScene();
            PlayerMovement.instance.canMove = true;
        }
    }

    void LoadNextScene()
    {
        ShouldLoadAfterFade = true;
        controller.uiFade.FadeToBlack();

        player.lastArea = exitName;
        
    }

}
