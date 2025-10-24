using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    // Goal is to be able to use scroll wheel to switch between arrays and each game object inside of the arrays are "setactive false" unless the array is selected by the player.

    // when switches, set active true and make current weapon = weapons.
    public GameObject currentWeapon; // The current weapon that the player starts with.

    public GameObject[] weapons; // The Weapons array "box" that the different weapons are located in the inspector.

    public int currentArrayNum = 1; // The game starts with the array number of 1.
    public int minArrayNum = 0; // The minimum number that the scroll wheel can reach.
    public int maxArrayNum = 2; // The maximum number that the scroll wheel can reach.

    // Start is called before the first frame update
    void Start()
    {
        // currentArrayNum = 1; // The game starts with the array number of 1.
        currentWeapon = weapons[0]; // The player starts the game with holding the first weapon "Player Rifle".
    }

    // Update is called once per frame
    void Update()
    {
        UpdateActiveWeapon(); // Active weapon is updating each frame.

        // Scoll up if statement.
        if(Input.mouseScrollDelta.y > 0)
        {
                currentArrayNum += 1;
                currentWeapon = weapons[currentArrayNum];

                // SwitchItem(); // Calls the switch item function to occur after the integer has changed. 
                Debug.Log("Scroll up");

                if(currentArrayNum >= maxArrayNum)
                {
                    currentArrayNum = maxArrayNum;
                    Debug.Log($"Array: [{string.Join(", ", currentArrayNum)}]");
                }
        } 
        if(Input.mouseScrollDelta.y < 0)
        {
                currentArrayNum -= 1;
                // SwitchItem();
                Debug.Log("Scroll down");
                currentWeapon = weapons[currentArrayNum];
                if(currentArrayNum <= minArrayNum)
                {
                    currentArrayNum = minArrayNum;
                    Debug.Log($"Array: [{string.Join(", ", currentArrayNum)}]");
                }
        }
    }

    // Updating the active weapons.
    void UpdateActiveWeapon()
    {
        foreach (GameObject weapon in weapons) // For each weapon in the weapons array-
        {
            weapon.SetActive(false); // They are all set active false.
        }

        // Activate only the selected one
        if (currentArrayNum >= 0 && currentArrayNum < weapons.Length)
        {
            currentWeapon = weapons[currentArrayNum];
            currentWeapon.SetActive(true);
            Debug.Log($" Activated weapon: {currentWeapon.name} (index {currentArrayNum})");
        }
        
        else if(currentArrayNum <= minArrayNum)
                {
                    currentArrayNum = minArrayNum;
                }

        else if (currentArrayNum >= maxArrayNum)
                {
                    currentArrayNum = maxArrayNum;
                }
    }
}
