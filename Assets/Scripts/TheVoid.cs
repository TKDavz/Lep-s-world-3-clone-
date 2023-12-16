using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVoid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObj = collision.gameObject;
 
        if(!(gameObj.CompareTag("Player") || gameObj.CompareTag("Wall") || gameObj.CompareTag("MapWall") || gameObj.CompareTag("Ground")) ) {
            Destroy(gameObj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player") || collision.CompareTag("Wall") || collision.CompareTag("MapWall") || collision.CompareTag("Ground")))
        {
            Destroy(collision.gameObject);
        }
    }


}
