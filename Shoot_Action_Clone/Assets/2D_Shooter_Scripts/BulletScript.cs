using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used for restarting and reloading a scene.

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos; // Position of the mouse.
    private Camera mainCam; // The main camera.
    public Rigidbody2D rb; // RigidBody
    public float force; // The number of force.

    Player player; // Reference to the player controller.
    
    // Start is called before the first frame update
    void Start() 
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Game finds the main camera.

        rb = GetComponent<Rigidbody2D>(); // The rigidbody gets the rigid body compoonent.

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // The mouse position is equal to the screen to the middle of the screen and when the mouse moves it follows.

        Vector3 direction = mousePos - transform.position; // The direction follows the mouse.
        Vector3 rotation = transform.position - mousePos; // The position of the mouse affects the rotate point.

        // Telling unity that the x and y position are going to apply force to the bullet upon its rotate position radius making the player able to shoot based on the direction of their cursor.
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; 
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, 0, rot + 90f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col) // When the bullet enters the npc
    {
            if(col.gameObject.name.Contains("Enemy")) // If the bullet collides with an object that contains the word Enemy
            {
                Debug.Log("Hitting");

                col.gameObject.GetComponent<EnemyHealth>().TakeDamage(1); // The npc takes damage with a value of 1 and grabs  the function of player health.
                
                Destroy(gameObject); // Once the npc health has reached 0 destroy npc health
            }           
    }
}
