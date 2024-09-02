using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] public float runSpeed = 2f;
    [SerializeField] public float jumpSpeed = 3f;
    Rigidbody2D rb2D;
    [SerializeField] private bool isGrounded;
    [SerializeField]public SpriteRenderer spriteRenderer;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.01f)
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }

    void Update()
    {

        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0, 0) * runSpeed * Time.deltaTime;
        transform.Translate(move);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    }
