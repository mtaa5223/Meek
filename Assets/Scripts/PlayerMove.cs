using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer rend;

    public float movePower = 10;
    public float jumpPower = 1;

    Rigidbody2D rb;
    Animator animator;

    bool isJumping = false;
    int jumpCount = 0;
    public int maxJumpCount = 2; // �ִ� ���� Ƚ��

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        Ani();
        Slam();
    }

    void Slam()
    {
        if (isJumping && Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("GroundSlam");

        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(horizontal, 0f, 0f) * movePower * Time.deltaTime;

        transform.Translate(movement);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && (jumpCount < maxJumpCount))
        {
            animator.SetBool("IsGround", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCount++;
            Debug.Log(jumpCount);
            if (jumpCount == 1)
            {
                animator.SetBool("Jump1", true);

            }
            if (jumpCount == 2)
            {
                animator.SetBool("Jump1", false);
                //isJumping = false;

                animator.SetBool("Jump2", true);
            }
            //if(jumpCount == 2 && Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    animator.SetBool("GroundSlam", true);
            //}
            //else
            //{
            //    animator.SetBool("GroundSlam", false);
            //}
        }

        // ���� ���� ���ȿ��� ���� �ִϸ��̼� ����

    }

    void Ani()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            if (horizontal > 0)
            {
                rend.flipX = false;
            }
            else if (horizontal < 0)
            {
                rend.flipX = true;
            }

            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Debug.Log("���� ����");

        }
    }

    // ���� üũ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("�浹");
            isJumping = false;
            jumpCount = 0; // ������ ������ ���� Ƚ�� �ʱ�ȭ
            animator.SetBool("Jump1", false);
            animator.SetBool("Jump2", false);
            animator.SetBool("IsGround", true);
        }
    }
}
