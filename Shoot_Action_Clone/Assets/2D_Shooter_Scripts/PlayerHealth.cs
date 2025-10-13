using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used for restarting and reloading a scene.

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f; // Player's current health and maximum health.

    private void start()
    {
        health = 3f;
        health = maxHealth; // At the start of the game the Player's current health is equal to the maximum health.
    }

    public void TakeDamage(float damageAmount) // How the Player takes damage.
    {
        health -= damageAmount; // The damage amount decreases the current health by 1 (3 - 2 - 1 - 0 = Player has died).
        Debug.Log("Taking damage"); 
        
        if(health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // game reloads the current scene (restarts the game)
        }
    }
}
