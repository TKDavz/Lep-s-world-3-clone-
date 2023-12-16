using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public Animation animationToDelay;
    public float delay = 1f;

    private void Start()
    {
        StartCoroutine(PlayAnimationWithDelay());
    }

    private IEnumerator PlayAnimationWithDelay()
    {
        yield return new WaitForSeconds(delay);
        animationToDelay.Play();
    }
}
