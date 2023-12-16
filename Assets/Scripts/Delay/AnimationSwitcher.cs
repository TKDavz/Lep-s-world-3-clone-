using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    public Animator animator;
    public AnimationClip animationA;
    public AnimationClip animationB;
    public float maxAnimationTime = 5f; // Thời gian tối đa của animation trước khi chuyển đổi

    private float currentAnimationTime = 0f;


    private void Start()
    {

    }

    private void Update()
    {

        currentAnimationTime += Time.deltaTime;
        if (currentAnimationTime >= maxAnimationTime)
        {
            SwitchAnimation();
            currentAnimationTime = 0f;
        }

    }

    private void OnEnable()
    {
        animator.Play(animationA.name);
    }

    private void SwitchAnimation()
    {
        animator.StopPlayback(); // Dừng animation hiện tại
        animator.Play(animationB.name); // Chuyển sang animation khác
    }
}
