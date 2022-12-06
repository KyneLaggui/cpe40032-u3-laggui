using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//The values of the starting position of the background
    private float repeatWidth;//The values of the width of the backgtround
    // Start is called before the first frame update
    void Start()
    {
        
        startPos = transform.position;//Calls the initial position of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;//Divide the Box Collider to its middle position
    }

    // Update is called once per frame
    void Update()
    {
        //If the collider reaches the middle part it will return to its initial position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
