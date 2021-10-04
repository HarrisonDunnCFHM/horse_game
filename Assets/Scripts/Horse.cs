using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    //config params
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float despawnDistance = 50f;
    [SerializeField] bool sillyMode;
    [SerializeField] AudioClip[] myAudioClips;
    [SerializeField] AudioClip[] mySillyClips;

    //cached refs
    int runDir;
    PlayerMove player;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        runDir = Random.Range(0, 2);
        if(runDir == 1)
        {
            
            transform.localScale = new Vector2 (-transform.localScale.x,transform.localScale.y);
        }
        sillyMode = AudioManager.sillyMode;
        audioManager = FindObjectOfType<AudioManager>();
        PlayAudioClip();
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
        DespawnFromRange();
    }
    public void PlayAudioClip()
    {
        if (!sillyMode)
        {
            int audioIndex = Random.Range(0, myAudioClips.Length);
            AudioSource.PlayClipAtPoint(myAudioClips[audioIndex], Camera.main.transform.position, audioManager.effectsVolume * audioManager.masterVolume);
        }
        else
        {
            int audioIndex = Random.Range(0, mySillyClips.Length);
            AudioSource.PlayClipAtPoint(mySillyClips[audioIndex], Camera.main.transform.position, audioManager.effectsVolume * audioManager.masterVolume * 2);
        }
    }
    public void DespawnFromRange()
    {
        var xToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        var yToPlayer = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (xToPlayer >= despawnDistance || yToPlayer >= despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
