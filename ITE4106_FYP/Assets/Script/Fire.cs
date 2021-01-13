using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public Rigidbody bullet;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update

    void Start()
    {
        GameStatus.menuIsOn = false;
    }

    void Update()
    {
        bulletSpeed = GameStatus.bulletspeed;
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        //fire
        if (Input.GetMouseButtonDown(0) & (GameStatus.menuIsOn == false))
        {
            shoot();   //call function allow player fire
            GameStatus.health -= GameStatus.firecontrol;   //reduice health
        }
    }

    void shoot()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;        // give velocity to the bullet
    }
}
