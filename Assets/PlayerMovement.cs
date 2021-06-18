using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 3.0f;
    public float normalSpeed = 3.0f;
    public float dashing = 5.0f;
    public float jumpForce = 200f;


    private Rigidbody2D _rigidbody2D;
    //for flip
    private bool facingRight = true;
    //for move
    public float horizontalMovement;
    //for jump 
    public Transform groundCheck;
    public float checkRadius;
    private bool isGrounded;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private int extraDash;
    public int extraDashValue;


    void Start()
    {
        extraJumps = extraJumpsValue;
        extraDash = extraDashValue;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);

        if(facingRight == false && horizontalMovement > 0)
        {
            Flip();
        }
        else if (facingRight== true && horizontalMovement <0)
        {
            Flip();
        }

        if(isGrounded == true)
        {
            extraJumps = 1;
            extraDash = 1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps>0)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = dashing;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (extraDash >= 1)
                {
                StartCoroutine("DashMove");
                --extraDash;
                }
        }

    }

    IEnumerator DashMove()
    {
        moveSpeed += 10;
        yield return new WaitForSeconds(0.3f);
        moveSpeed -= 10;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
