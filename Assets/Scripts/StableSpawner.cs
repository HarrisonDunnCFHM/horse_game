using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableSpawner : MonoBehaviour
{
    //config params
    [SerializeField] Stables stablePrefab;
    [SerializeField] Camera mainCamera;
    [SerializeField] float minSpawnDist = 3f;
    [SerializeField] public float maxSpawnDist = 50f;
    [SerializeField] public float minBetweenStables = 2f;
    [SerializeField] int maxSpawns = 20;

    //cached refs
    PlayerMove player;
    int currentStables = 0;
    float cameraOrthSize;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        cameraOrthSize = mainCamera.orthographicSize;
        minSpawnDist = cameraOrthSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnStables();
    }

    private void SpawnStables()
    {
        if (currentStables >= maxSpawns) { return; }
        var spawnPos = GetSpawnPos();
        if (!CheckForValidPos(spawnPos)) { return; }
        Instantiate(stablePrefab, spawnPos, Quaternion.identity);
        currentStables++;
    }

    private Vector2 GetSpawnPos()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 spawnPos = (Random.insideUnitCircle * maxSpawnDist) + playerPos;
        return spawnPos;
    }

    private bool CheckForValidPos(Vector3 spawnPos)
    {
        var otherStables = new List<Stables>(FindObjectsOfType<Stables>());
        if (otherStables.Count == 0) { return true; }
        foreach(Stables otherStable in otherStables)
        {
            float distToStable = Vector2.SqrMagnitude(spawnPos - otherStable.transform.position);
            if (distToStable <= (minBetweenStables * minBetweenStables)) { return false; }
        }
        float distToPlayer = Vector2.SqrMagnitude(spawnPos - player.transform.position);
        if(distToPlayer <= (minSpawnDist * minSpawnDist)) { return false; }
        return true;
    }

    public void DespawnStable()
    {
        currentStables--;
    }

    
}
