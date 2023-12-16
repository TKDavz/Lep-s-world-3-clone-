using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerWhenTagCollides : MonoBehaviour
{
    public string tagName;
    public Collider2D colliderNoneTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            colliderNoneTrigger.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            colliderNoneTrigger.isTrigger = false;
        }
    }

}
