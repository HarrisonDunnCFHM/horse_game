using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 6f;

    //cached refs
    int runDir;

    // Start is called before the first frame update
    void Start()
    {
        runDir = Random.Range(0, 2);
        if(runDir == 1)
        {
            
            transform.localScale = new Vector2 (-transform.localScale.x,transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (runDir == 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
