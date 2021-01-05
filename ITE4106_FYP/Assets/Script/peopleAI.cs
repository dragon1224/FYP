using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class peopleAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    int x, y, z;

    [SerializeField] GameObject girl;
    [SerializeField] GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        x = Random.Range(-50, 50);
        z = Random.Range(50,- 50);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(new Vector3(x, 0f, z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")  //check if it hit enemy
        {
            girl.SetActive(false);
            zombie.SetActive(true);
        }
    }
}
