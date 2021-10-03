using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (ZombieCowboy.gameOver) { ZombieCowboy.gameOver = false; }

    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieCowboy.gameOver) { return; }
        PlayerMovement();
        FlipSprite();
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
