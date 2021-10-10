using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllr : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        this.player = GameObject.FindWithTag("cat");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(this.player == null )
        {
            this.player = GameObject.FindGameObjectWithTag("cat");
            return;
        }
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);

    }
}
