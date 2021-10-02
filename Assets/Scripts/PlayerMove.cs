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
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            var dir = Input.GetAxis("Horizontal");
            var newX = transform.position.x + (moveSpeed * Time.deltaTime * dir);
            transform.position = new Vector2(newX, transform.position.y);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            var dir = Input.GetAxis("Vertical");
            var newY = transform.position.y + (moveSpeed * Time.deltaTime * dir);
            transform.position = new Vector2(transform.position.x, newY);
        }
    }
}
