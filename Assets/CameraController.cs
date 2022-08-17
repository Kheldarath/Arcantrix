using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    Player player; //reference to player
    public Transform target; //target for camera to follow    

    [SerializeField]Tilemap theMap;

    private Vector3 topRightLimit; //camera bounding 
    private Vector3 bottomLeftLimit; //camera bounding

    private float halfHeight, halfWidth;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        target = player.transform;
    }

    private void Start()
    {        

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth,-halfHeight,0f);
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth,halfHeight,0f);


        
    }

    private void Update()
    {
      transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

      transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
