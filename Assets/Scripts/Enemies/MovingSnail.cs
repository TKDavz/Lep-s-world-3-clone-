using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSnail : MonoBehaviour
{
    public GameObject MovingSnailPrefab;
    public GameObject newGameObject;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation_z = transform.rotation.z;

        if ((rotation_z > 10 && rotation_z < 90))
        {
            animator.SetBool("isCrawling", false);
            animator.SetBool("intoTheShell", true);
            animator.SetBool("isStay", true);
        }
        else
        {
            Debug.Log("rota" + rotation_z);
            animator.SetBool("isCrawling", true);
            animator.SetBool("isStay", false);
            animator.SetBool("intoTheShell", false);

        }


    }
}
