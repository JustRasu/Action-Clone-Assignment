using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float force;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Getting the rb.
        player = GameObject.FindGameObjectWithTag("Player"); // Finding the player.

        Vector3 direction = player.transform.position - transform.position; // 
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; //

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; // 
        transform.rotation = Quaternion.Euler(0, 0, rot + 90); // bullet rotates and shoots at 90 degrees.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col) // When the bullet collides with the player
    {
        Debug.Log("Hit something " + col.gameObject.name);
            if(col.gameObject == player)
            {
                Debug.Log("Hitting");

                col.gameObject.GetComponent<PlayerHealth>().TakeDamage(1); // The npc takes damage with a value of 1 and grabs  the function of player health.
                
                Destroy(gameObject); // Once the npc health has reached 0 destroy npc health
            }           

    }
}