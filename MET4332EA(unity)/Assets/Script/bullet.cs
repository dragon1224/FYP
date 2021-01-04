using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private bullet bul;
    private float lifetime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        GameStatus.bulletlife = lifetime;
    }
    private void Awake()
    {
        Destroy(gameObject, lifetime); // destroy gameObject that script is attached to
    }
}
