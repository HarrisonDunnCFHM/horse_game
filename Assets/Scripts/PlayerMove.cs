using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 5f;

    //cached refs
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        if (ZombieCowboy.gameOver) { ZombieCowboy.gameOver = false; }
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieCowboy.gameOver) { return; }
        //PlayerMovement();
        PlayerMovementFixed();
        FlipSprite();
    }

    private void PlayerMovementFixed()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") + transform.position.x;
        float moveVertical = Input.GetAxisRaw("Vertical")  + transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveHorizontal, moveVertical, transform.position.z), moveSpeed * Time.deltaTime);
        //transform.position = new Vector3 (moveHorizontal, moveVertical, transform.position.z);
        
    }

    private void PlayerMovement()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            var dir = Input.GetAxis("Horizontal");
            var newX = transform.position.x + (moveSpeed * Time.deltaTime * dir);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            var dir = Input.GetAxis("Vertical");
            var newY = transform.position.y + (moveSpeed * Time.deltaTime * dir);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

    }

    private void FlipSprite()
    {
        var dir = Input.GetAxis("Horizontal");
        if (dir == 0) { return; }
        if (Mathf.Sign(dir) == Mathf.Sign(transform.localScale.x))
        {
            var newDir = transform.localScale.x * -1;
            transform.localScale = new Vector3(newDir, transform.localScale.y, transform.localScale.z);
        }
    }
}
