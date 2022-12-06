using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;//Speed of the environment and obstacles
    private PlayerController playerControllerScript;//To get the component of Player Controller
    private float leftBound = -15;//The value where the boundary of obstacle will be destroyed
    // Start is called before the first frame update
    void Start()
    {
        //To access the component of player controller
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the game over values is false, meaning the game is still running
        if (playerControllerScript.gameOver == false)
        {
            //To apply the speed to the background and obstacles
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //If the game over is equivalent to true meaning the background and obstacles will not move

        //To destroy the obstacles that are out of the boundary
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
