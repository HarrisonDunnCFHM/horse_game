using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stables : MonoBehaviour
{
    enum StableType { Up, Down, Left, Right };
    //config params
    [SerializeField] float minDistBetweenStables = 3f;
    [SerializeField] Horse horse;
    [SerializeField] Sprite[] stableTypes;
    
    
    //cached references
    ScoreKeeper scoreKeeper;
    StableSpawner stableSpawner;
    PlayerMove player;
    float maxSpawnDist;
    List<Stables> otherStables;
    StableType myType;
    Sprite mySprite;
    StableType myUnlockKey;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        stableSpawner = FindObjectOfType<StableSpawner>();
        player = FindObjectOfType<PlayerMove>();
        maxSpawnDist = stableSpawner.maxSpawnDist;
        mySprite = GetComponent<SpriteRenderer>().sprite;
        PickDirection();
        InitializeStableType();
    }

    private void InitializeStableType()
    {
        myType = (StableType)Random.Range(0, 4);
        switch(myType)
        {
            case StableType.Up:
                GetComponent<SpriteRenderer>().sprite = stableTypes[0];
                myUnlockKey = myType;
                break;
            case StableType.Down:
                GetComponent<SpriteRenderer>().sprite = stableTypes[1];
                myUnlockKey = myType;
                break;
            case StableType.Left:
                GetComponent<SpriteRenderer>().sprite = stableTypes[2];
                myUnlockKey = myType;
                if(transform.localScale.x <= 0) { myUnlockKey = StableType.Right; }
                break;
            case StableType.Right:
                GetComponent<SpriteRenderer>().sprite = stableTypes[3];
                myUnlockKey = myType;
                if (transform.localScale.x <= 0) { myUnlockKey = StableType.Left; }
                break;
            default:
                break;
        }
    }

    private void PickDirection()
    {
        var isRight = Random.Range(0,2);
        if (isRight == 0)
        {
            var newX = -transform.localScale.x;
            transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DespawnFromRange();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (ZombieCowboy.gameOver) { return; }
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            switch(myUnlockKey)
            {
                case StableType.Up:
                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        SpawnHorse();
                    }
                    break;
                case StableType.Down:
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        SpawnHorse();
                    }
                    break;
                case StableType.Left:
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        SpawnHorse();
                    }
                    break;
                case StableType.Right:
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        SpawnHorse();
                    }
                    break;
            }
        }
    }

    

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMove>())
        {
            
            scoreKeeper.IncreaseScore();
            stableSpawner.DespawnStable();
            SpawnHorse();
            Destroy(gameObject);
        }
    }*/

    private void SpawnHorse()
    {
        Instantiate(horse, transform.position, Quaternion.identity);
        scoreKeeper.IncreaseScore();
        stableSpawner.DespawnStable();
        Destroy(gameObject);
    }

    public void DespawnFromRange()
    {
        var xToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        var yToPlayer = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (xToPlayer >= maxSpawnDist || yToPlayer >= maxSpawnDist)
        {
            stableSpawner.DespawnStable();
            Destroy(gameObject);
        }
    }

    public void DespawnIfTooCloseToOtherStable()
    {
        otherStables = new List<Stables>(FindObjectsOfType<Stables>());
        if (otherStables.Count == 0) { return; }
        foreach (Stables otherStable in otherStables)
        {
            float distToX = Mathf.Abs(transform.position.x - otherStable.transform.position.x);
            float distToY = Mathf.Abs(transform.position.y - otherStable.transform.position.y);
            if(distToX <= minDistBetweenStables || distToY <= minDistBetweenStables)
            {
                Debug.Log("too close");
                stableSpawner.DespawnStable();
                Destroy(gameObject); 
            }
        }
    }
}
