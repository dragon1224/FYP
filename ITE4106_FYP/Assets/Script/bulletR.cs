using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletR : MonoBehaviour
{
    private bullet bulR;
    private float lifetimeR = 300f;

    // Start is called before the first frame update
    void Start()
    {
        GameStatus.bulletlifeR = lifetimeR;
    }
    private void Awake()
    {
        Destroy(gameObject, lifetimeR); // destroy gameObject that script is attached to
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  //check if it hit player
        {
            GameStatus.health -= 10;
            Destroy(gameObject);        //self-destruct
        }
    }
}
