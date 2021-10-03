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
    PopOutMenu gameOverMenu;
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameOverMenu = FindObjectOfType<PopOutMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        FlipSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (gameOver) { return; }
            gameOver = true;
            Debug.Log("game over!");
            gameOverMenu.ToggleMenu();
            PlayerPrefs.SetInt("lastscore", scoreKeeper.score);
            if(scoreKeeper.score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", scoreKeeper.score);
            }
        }
    }

    private void ChasePlayer()
    {
        if(scoreKeeper.score <= 0) { return; }
        var playerPos = player.transform.position;
        float scoreMult = (Mathf.Log(scoreKeeper.score, speedGrowth)) + 1;
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime * scoreMult);
    }

    private void FlipSprite()
    {
        var dir = player.transform.position.x - transform.position.x;
        if (dir == 0) { return; }
        if (Mathf.Sign(dir) == Mathf.Sign(transform.localScale.x))
        {
            var newDir = transform.localScale.x * -1;
            transform.localScale = new Vector3(newDir, transform.localScale.y, transform.localScale.z);
        }
    }
}
