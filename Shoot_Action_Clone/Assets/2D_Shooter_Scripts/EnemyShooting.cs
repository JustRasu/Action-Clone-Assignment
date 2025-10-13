using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet; // The bullet game obj.
    public Transform bulletPos; // The position of the bullet and its rotation.

    public float timer; // Controlling the frequency that the bullet spawns in our scene.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Our timer goes up by seconds.

        if(timer > 2)
        { // If two seconds pass the timer resets to 0.
            timer = 0; 
            shoot(); // The bullet fires.
        }
        
        else 
        {
            return; // returns to the start of the If statement. Resets the If.
        }
    }

    void shoot() 
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity); // Instantiates the bullet game object based on the rotation of the enemy tracking the player.
    }

}
