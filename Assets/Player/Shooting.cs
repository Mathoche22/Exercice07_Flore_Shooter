using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint; // get bullet's direction
    public GameObject BulletPrefab; // get the bullet object

    public float BulletForce = 20f; // instantiate bullet's force value


    // Update is called once per frame
    void Update()
    {
        // fonction if to call the shooting
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot(); // whenever the button is down the player will shoot
        }
    }

    // determinate the parameters of the shooting fonction
    void Shoot()
    {
        // make the bullet spawn and move
        GameObject Bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * BulletForce, ForceMode2D.Impulse);
    }

}

