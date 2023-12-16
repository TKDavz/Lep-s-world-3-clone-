using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //bool chamNen = true;
    int doubleJump = 2;

    int numberCoins = 0;
    public Text textCoin;

    Rigidbody2D rigid;
    public float speed = 5f;
    public float jumpForce = 350f;

    public float maximumTimeInsideEnemy = 2f;
    private float timeInsideEnemy = 0f;


    Animator animator;
    public float maxAnimationTime = 6f; // Thời gian tối đa của animation trước khi chuyển đổi
    private float currentAnimationTime = 0f;

    private bool canKillEnemy = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        try
        {
            if (SinglePatterns.Instance.isContinue && SceneManager.GetActiveScene().name == SinglePatterns.Instance.PlayScene)
            {
                transform.position = SinglePatterns.Instance.Position;
                numberCoins = SinglePatterns.Instance.Score;
            }
        } catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //isRight = true;
            HorizontalMove(true);

        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //isRight = false;
            HorizontalMove(false);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            JumpUp();
        }

        currentAnimationTime += Time.deltaTime;
        if (currentAnimationTime >= maxAnimationTime)
        {
            animator.SetBool("isHand", true);
            currentAnimationTime = 0f;
        }
    }

    private void HorizontalMove(bool isRight)
    {
        animator.SetBool("isRunning", true);

        currentAnimationTime = 0f;
        animator.SetBool("isHand", false);

        //transform.Translate(Time.deltaTime * speed * -1, 0, 0);
        //Vector2 v = transform.localScale;
        //v.x *= (v.x > 0) ? -1 : 1;
        //transform.localScale = v;

        transform.Translate(Time.deltaTime * speed * (isRight ? 1f : -1f), 0, 0);
        Vector2 v = transform.localScale;
        v.x *= (isRight && v.x < 0) || (!isRight && v.x > 0) ? -1 : 1;
        transform.localScale = v;
    }

    private void JumpUp()
    {
        if (doubleJump > 0)
        {
            animator.SetBool("isJump", true);
            animator.SetBool("isEnterGround", false);

            currentAnimationTime = 0f;
            animator.SetBool("isHand", false);

            doubleJump--;
            Debug.Log("doup: " + doubleJump);

            rigid.AddForce(Vector2.up * jumpForce);
        }

    }

    private IEnumerator DelayedGroundCollision()
    {
        yield return new WaitForSeconds(0.6f); // Delay 0.6 giay

        animator.SetBool("isJump", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObj = collision.gameObject;

        if (gameObj.CompareTag("Ground") || gameObj.CompareTag("Block"))
        {
            animator.SetBool("isEnterGround", true);
            animator.SetBool("isJump", false);
            //chamNen = true;
            doubleJump = 2;
            //StartCoroutine(DelayedGroundCollision());

            //Debug.Log("cham nen: " + chamNen);
            //Debug.Log("isJump: " + animator.GetBool("isJump"));
            //Debug.Log("isEnterGround: " + animator.GetBool("isEnterGround"));
        }

        if (gameObj.CompareTag("Enemy"))
        {
            Debug.Log("canKillEnemy: " + canKillEnemy);
            if (collision.GetContact(0).normal.y > 0)
            {
                canKillEnemy = true;
            }
            else
            {
                canKillEnemy = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LethalArea"))
        {

            FadeInOut fadeInOut = GetComponent<FadeInOut>();
            if (fadeInOut != null)
            {
                fadeInOut.StartFading();
            }
            timeInsideEnemy = 0f;

        }

        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Scene5");
        }

        if (collision.CompareTag("BoxCoin"))
        {
            Destroy(collision.gameObject);
            numberCoins++;
            SetCoin();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LethalArea"))
        {

            timeInsideEnemy += Time.deltaTime;

            if (timeInsideEnemy >= maxAnimationTime)
            {
                FadeInOut fadeInOut = GetComponent<FadeInOut>();
                if (fadeInOut != null)
                {
                    fadeInOut.StartFading();
                }
                timeInsideEnemy = 0f;
            }
        }

        if (collision.CompareTag("KillZone"))
        {
            JumpUp();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LethalArea"))
        {
            timeInsideEnemy = 0f;
        }


    }

    public void SetCoin()
    {
        if (textCoin != null)
        {
            textCoin.text = numberCoins + "";
        }
    }

}



