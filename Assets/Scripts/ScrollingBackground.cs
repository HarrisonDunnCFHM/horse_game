using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //config params
    [SerializeField] float scrollHSpeed = .039f;
    [SerializeField] float scrollVSpeed = .056f;


    Material myMaterial;
    PlayerMove player;

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        //float moveHorizontal = Input.GetAxisRaw("Horizontal") - myMaterial.mainTextureOffset.x;
        //float moveVertical = Input.GetAxisRaw("Vertical") - myMaterial.mainTextureOffset.y;
        //myMaterial.mainTextureOffset = Vector2.MoveTowards(myMaterial.mainTextureOffset, new Vector3(moveHorizontal, moveVertical), scrollSpeed * Time.deltaTime);
        myMaterial.mainTextureOffset = new Vector2(Camera.main.transform.position.x * scrollHSpeed, Camera.main.transform.position.y * scrollVSpeed);

    }
}
