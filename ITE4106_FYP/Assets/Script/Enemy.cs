using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private player player;
    private Vector3 previousPosition;
    public float health;
    //public float curSpeed;
    public Transform Player;
    public LayerMask whatIsGround, whatIsPlayer;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject Bullet;

    //States

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    [SerializeField] GameObject girl;
    [SerializeField] GameObject zombie;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //keep update and chasing player
        /*navMeshAgent.SetDestination(player.transform.position);

        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;  
        previousPosition = transform.position; */
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) 
            Patroling();
        if (playerInSightRange && !playerInAttackRange) 
            ChasePlayer();
        if (playerInSightRange && !playerInAttackRange) 
            AttackPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  //check if it hit player
        {
            GameStatus.health -= 25;    //decrease player health
            Destroy(gameObject);        //self-destruct
        }

        if (other.tag == "Bullet")  //check if it hit by bullet
        {
            GameStatus.score += 1;      //add score
            GameStatus.currentexp += 1; //xp
            /*if (GameStatus.health <= 195){ 
            GameStatus.health += 5;     //add health if it is not maxed
            }*/
            girl.SetActive(true);
            zombie.SetActive(false);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(Player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }    
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {

        Destroy(gameObject);
    }
}
