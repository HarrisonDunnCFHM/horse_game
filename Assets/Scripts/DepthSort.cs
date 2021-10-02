using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SortDepth();
    }

    private void SortDepth()
    {
        var myY = transform.position.y;
        float newZ = myY * .01f;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
