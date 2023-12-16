using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBasedAnimation : MonoBehaviour
{
    public float activationDistance = 10f;
    public Animator animator;
    public string tagName;

    private void Start()
    {
        
    }

    private void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance <= activationDistance)
            {
                obj.GetComponent<Animator>().enabled = true;
            }
            else
            {
                obj.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
