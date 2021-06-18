using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float speed = 2.0f;
    public float dashing = 4.0f;

    public float jumpForce = 250f;
    private Rigidbody2D _rigidbody2D;

    private float horizontalMovement;


   // public Transform groundcheck;
   // private bool isGrounded;
   // public LayerMask layerground;
   // public float radius = 0.6f;

    public int numberJumps = 1;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);

      //  isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, layerground);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x *= -1;
            SoundManagerScript.PlaySound("jump");

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 5f;
            SoundManagerScript.PlaySound("jump");

        }
        transform.localScale = characterScale;

        if (Input.GetKeyDown(KeyCode.W))
        {
            SoundManagerScript.PlaySound("jump");
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            //--numberJumps;
        }

      //  if (isGrounded)
      //  {
      //      numberJumps = 1;
      //  }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = dashing;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = speed;
        }


    }


}
