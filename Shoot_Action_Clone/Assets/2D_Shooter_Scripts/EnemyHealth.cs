using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Used for restarting and reloading a scene.

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f; // NPC's current health and maximum health.

    private void start()
    {
        health = 2f; // The health that the enemy starts on.
        health = maxHealth; // At the start of the game the NPC's current health is equal to the maximum health.
    }

    public void TakeDamage(float damageAmount) // How the NPC takes damage.
    {
        health -= damageAmount; // The damage amount decreases the current health by 1 (3 - 2 - 1 - 0 = Enemy has died).
        Debug.Log("Taking damage"); 
        
        if(health <= 0) // if the health is less or equal to 0-
        {
            Debug.Log("Dead");
            Destroy(gameObject); // Game obj gets destroyed.
        }
    }
}
