using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public Rigidbody bullet;
    [SerializeField] float bulletSpeed = 30f;
    // Start is called before the first frame update

    void Start()
    {
        GameStatus.bulletspeed = bulletSpeed;

    }

    // Update is called once per frame

    
    void Update()
    {
        //fire
        if (Input.GetMouseButtonDown(0))
        {
            shoot();                         //call function allow player fire
            GameStatus.health -= GameStatus.firepower;
        }
    }

    void shoot()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;        // give velocity to the bullet
    }
}
