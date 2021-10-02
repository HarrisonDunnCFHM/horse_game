using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stables : MonoBehaviour
{
    //config params
    [SerializeField] float minDistBetweenStables = 3f;
    [SerializeField] Horse horse;
    
    
    //cached references
    ScoreKeeper scoreKeeper;
    StableSpawner stableSpawner;
    PlayerMove player;
    float maxSpawnDist;
    List<Stables> otherStables;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        stableSpawner = FindObjectOfType<StableSpawner>();
        player = FindObjectOfType<PlayerMove>();
        maxSpawnDist = stableSpawner.maxSpawnDist;
        PickDirection();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMove>())
        {
            scoreKeeper.IncreaseScore();
            stableSpawner.DespawnStable();
            SpawnHorse();
            Destroy(gameObject);
        }
    }

    private void SpawnHorse()
    {
        Instantiate(horse, transform.position, Quaternion.identity);
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
