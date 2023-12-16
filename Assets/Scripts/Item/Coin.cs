using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public bool destroy = true;
    public float delayDestroy = 0.6f;
    Animator animator;
    public Collider2D colliderNoneTrigger;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (destroy)
            {
                if (rigid != null)
                {
                    rigid.bodyType = RigidbodyType2D.Kinematic;
                    rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                StartCoroutine(PlayAnimationsAndDestroy());
            }
            else
            {
                animator.SetBool("isBreak", true);

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (destroy)
            {
      
            }
            else
            {
                animator.SetBool("isBreak", false);
            }

        }
    }

    IEnumerator PlayAnimationsAndDestroy()
    {
        // Chạy animation đầu tiên
        animator.SetBool("isBreak", true);
        if (colliderNoneTrigger != null)
        {
            colliderNoneTrigger.enabled = false;
        }

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);
        //Debug.Log(animator.GetNextAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(delayDestroy); // Đợi cho đến khi animation đầu tiên kết thúc

        Destroy(gameObject); // Xóa game object
    }
}
