using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For the Player's Components
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    //For the Audio and Particles
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    //For the variable values
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver; //Default value is false

    // Start is called before the first frame update
    void Start()
    {
        //To access the existing components
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        //To modify the gravity of the Player
        Physics.gravity *= gravityModifier;//Physics function in the game
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is on ground and the game is not over
        //To get the player's spacebar Input
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //This added a force by the use of Physics
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

            isOnGround = false;//Means the player is not on ground
            playerAnim.SetTrigger("Jump_trig");//Animation in jumping
            dirtParticle.Stop();//To stop the dirt particle while the user is on mid air
            //Added the audio, the first parameter is the sound and the second is the volume
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Compare tag is used to define the gameObjects tag
        if (collision.gameObject.CompareTag("Ground"))//The player touches the ground
        {
            isOnGround = true;//The player is on ground
            dirtParticle.Play();//The dirt particle will continue 
        }
        else if(collision.gameObject.CompareTag("Obstacle"))//The player touches the obstacle
            {
            Debug.Log("Game Over"); //Will display at the console if the game is over
            gameOver = true;//The game is over
            playerAnim.SetBool("Death_b", true);//To play the animation of the death
            playerAnim.SetInteger("DeathType_int", 1);//To get the animation of death 1
            explosionParticle.Play();//The explosion particle will play if the player collides with obstacle
            dirtParticle.Stop();//The particle will stop because the character is not moving
            playerAudio.PlayOneShot(crashSound, 1.0f);//If the player collides with the object this will play

        }
    }
}
