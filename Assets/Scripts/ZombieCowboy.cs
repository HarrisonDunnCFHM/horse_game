using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCowboy : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float speedGrowth = 0.01f;

    //cached refs
    PlayerMove player;
    ScoreKeeper scoreKeeper;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ChasePlayer()
    {
        if(scoreKeeper.score <= 0) { return; }
        var playerPos = player.transform.position;
        float scoreMult = (Mathf.Log(scoreKeeper.score, speedGrowth)) + 1;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime * scoreMult);
    }
}
