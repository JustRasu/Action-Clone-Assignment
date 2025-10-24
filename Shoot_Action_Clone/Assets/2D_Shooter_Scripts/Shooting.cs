using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : WeaponSwitching
{
    // public Shooting 
    private Camera mainCam; // camera
    private Vector3 mousePos; // mouse position

    public GameObject bullet; // bullet game object 
    public Transform bulletTransform; // the transform point of the bullet
    public bool canFire; // When the player can fire
    public float timer; // The timer that keeps track of firing
    public float timeBetweenFiring; // Time in between firing

    // Start is called before the first frame update
    void Start() 
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // main cam finds the maincamera
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // each time the player rotates their mouse it updates so the bullet will follow

        Vector3 rotation = mousePos - transform.position; // Insures the bullet is properly following the map

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // The rotation of the bullet follows the same math as the rotation point

        transform.rotation = Quaternion.Euler(0,0,rotZ); // The rotation is transformed but not influence by the mousPos directly.

        if(! canFire) // When the player fires.
        {
            timer += Time.deltaTime; // The timer starts
            if(timer > timeBetweenFiring) // If the timer is greater than the time between firing-
            {
                canFire = true; // The player fires.
                timer = 0; // and the timer goes back to zero.
            }
        }

        if(Input.GetMouseButton(0) && canFire) // If the player is holding down left mouse, canFire is called-
        {
            canFire = false; // The timer resets and starts again immediatley which instantiates a new bullet.
            Instantiate(bullet, bulletTransform.position, Quaternion.identity); // The bullet is duplicated (instantiated) based on the transform position and is given a new sprite intirely.
        }

        // if(currentArrayNum = 0)
        // {
        //     timeBetweenFiring = 0.15f;
        // }

        // if(currentArrayNum = 1)
        // {
        //     timeBetweenFiring = 0.2f; 
        // }

        // if(currentArrayNum = 2)
        // {
        //     timeBetweenFiring = 0.5f;
        // }
    }
}
