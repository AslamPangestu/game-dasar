using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Control : MonoBehaviour {

    bool isJump = true;
    bool isDead = false;
    int idMove = 0;

    Animator anim;
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        Move();
        Dead();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        anim.SetTrigger("jump");
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        isJump = true;
    }
    public void MoveRight()
    {
        idMove = 1;
    }
    public void MoveLeft()
    {
        idMove = 2;
    }
    private void Move()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat           
            if (GetComponent<Rigidbody2D>().velocity.y < 1)
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        }
    }
    public void Idle()
    {
        if (!isJump)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
            // kondisi ketika idle/diam
        }
        idMove = 0;
    }
    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                // kondisi ketika jatuh
                SceneManager.LoadScene("Gameover");
                isDead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 15;
            Destroy(collision.gameObject);
        }
    }
}
