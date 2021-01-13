using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private bullet bul;
    public float lifetime = 1f;

    // Start is called before the first frame update
    
    private void Awake()
    {
        lifetime = GameStatus.bulletlife;
        Destroy(gameObject, lifetime); // destroy gameObject that script is attached to
    }
}
