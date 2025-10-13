// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI; // In order to use Text and text.text variables.
using UnityEngine.SceneManagement; // Used for restarting and reloading a scene.

    // Int = integer is a whole number, a real number.
    // Bool = boolean is true/false.
    // String is a combination of letters “Hello world”.
    // Float is a decimal.
    // Kinematic = 
    // Dynamic = 
    // == is when something already is equal to.
    // = is setting something equal to.
    // . accesses properties.
    // turbulent displace.

public class Player : MonoBehaviour
{
    public Animator animController; // The player's animation controller.
    public SpriteRenderer playerSpriteRenderer; // Our character sprite.

    public Shooting shootClass;
   
    public enum PlayerState
    {
        idle,
        shooting,
    }

    public PlayerState currentState; // references the Playerstate class.

    // Have mercy on the lack of animations and audio, I had way too many errands to do saturday-----

    public float speed = 4f; // The player moves 6 units per second. 
    public Rigidbody2D rb; // Rigid Body of player.
    public Camera cam; // The main camera which follows the player.

    public GameObject gun;
    public GameObject rotatePoint;
    // public Transform player; // Reference to the player's transform
    
    private float inputVel; // The input velocity of wasd controls.   

    private string currentNPC; // Whatever npc we are talking to.

    // Start is called before the first frame update.
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        rb.velocity = MovePlayer();
        cam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10); 
        // camera's position transforms orientation based on the players x & y positition- following player.

    }

    public Vector2 MovePlayer()
    {
        Vector2 input = rb.velocity; // A vector that will store updated velocity.

        // WASD Controlls.

        if(Input.GetKey(KeyCode.W)) // if w is pressed the player-
        {
            input.y = speed; // player moves towards the y position (up)
            animController.SetBool("isMoving", true); // When the player is moving the animation controller calls the isMoving animation onto the sprite.
        } 

        else if (Input.GetKey(KeyCode.S)) // if s is pressed the player-
        {
            input.y = -speed; // Player moves down (-y)
            animController.SetBool("isMoving", true); // When the player is moving the animation controller calls the isMoving animation onto the sprite.
        }

        else
        {
            input.y = 0; // if the player doesnt do this, they stay in place 
            animController.SetBool("isMoving", false); // When the player is not moving the animation controller stops the isMoving animation of the sprite.
        }

        if(Input.GetKey(KeyCode.A)) // If a is pressed
        {
            input.x = -speed; // player moves towards the left negative x
            playerSpriteRenderer.flipX = true; // Flips the sprite.
            animController.SetBool("isMoving", true); // When the player is moving the animation controller calls the isMoving animation onto the sprite.
        }
        else if(Input.GetKey(KeyCode.D)) // when d is pressed.
        {
            input.x = speed; // player moves towards the right x
            playerSpriteRenderer.flipX = false; // does not flip the sprite.
            animController.SetBool("isMoving", true); // When the player is moving the animation controller calls the isMoving animation onto the sprite.
        }
        else
        {
            input.x = 0; // if the player doesnt do this, they stay in place.
            animController.SetBool("isMoving", false); // isMoving animation stops when player stop smoving.
        }
        
        return input; // Returns our created vector2.
    }
}