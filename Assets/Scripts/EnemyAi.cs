using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    //Guard Stuff
    public GameObject guardposition;
    private bool EnemyGuard;
    public Transform Guard;


    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private Animator enemyAnim;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attackChance;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int attackDamage;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Scripts
    public HUD playerHUD;

    private void Awake()
    {
        guardposition = gameObject;
        Guard = gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerHUD = GameObject.Find("Player").GetComponent<HUD>();
        enemyAnim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Check if the enemy is a guard
        if (this.gameObject.tag == "Guard")
        {
            EnemyGuard = true;
        }

        if (EnemyGuard == true)
        {
            if (!playerInSightRange) Idle();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
        else
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange)
            {

                float rand = Random.Range(0, 1);
                if (rand <= attackChance)
                {
                    AttackPlayer();
                }
            }
        }
    }



    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Caculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {

        agent.SetDestination(player.position);
        //Debug.Log(agent.destination.ToString());
        //agent.isStopped = false;
        Walk();
    }

    private void AttackPlayer()
    {
        
        //trigger animation and deal damage
        Attack();
        Invoke("DamagePlayer", .5f);
       
    }

    private void DamagePlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        //transform.LookAt(player);
        Vector3 LookDirection = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        transform.LookAt(LookDirection);



        ///Attack code here
        //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        if (!alreadyAttacked)
        {
            //GetComponent<Animator>().Play("EnemyAxeSwing");
            playerHUD.TakeDamage(attackDamage + Random.Range(0, 10));
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Idle()
    {
        enemyAnim.SetTrigger("Idle");

        if (guardposition.transform.position != Guard.transform.position)
        {
            Guard.position = guardposition.transform.position;
        }
    }

    private void Attack()
    {
        float rand = Random.Range(0,1);

        if (rand < .5f)
            enemyAnim.SetTrigger("Attack 1");
        else if (rand <= 1f)
            enemyAnim.SetTrigger("Attack 2");

    }

    private void Walk()
    {
        enemyAnim.SetTrigger("Walking");
    }
}
