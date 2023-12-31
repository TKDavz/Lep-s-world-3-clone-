using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObjectOnTrigger : MonoBehaviour
{
    public GameObject gameObjectToggle;
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
        if (collision.CompareTag("Player"))
        {
            if (gameObjectToggle != null)
            {
                gameObjectToggle.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObjectToggle != null)
            {
                gameObjectToggle.SetActive(true);
            }
        }
    }
}
