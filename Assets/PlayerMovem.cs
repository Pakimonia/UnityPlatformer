using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private Animator anim;

    private enum MovementState{idle, runing };



    private float dirX;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimatorState();
    }
    void UpdateAnimatorState()
    {
        MovementState state;
        if(dirX > 0f)
        {
            state = MovementState.runing;
        }
        else if(dirX < 0f)
        {
            state = MovementState.runing;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }
}
