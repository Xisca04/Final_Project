using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //SLIME ENEMY

    [SerializeField] private Transform player;
    [SerializeField] private PlayerController _playerController;

    private NavMeshAgent _agent;
    private Animator _animator;

    //Live n Damage
    private int slimeLives = 1;
    private float slimeDamge = 1f;
    private int turtleLives = 2;
    private float turtleDamage = 2f;

    private float visionRange = 3.5f;
    private float attackRange = 2f;

    [SerializeField] private bool playerInVisionRange;
    [SerializeField] private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    // PATRULLA - Variables

    [SerializeField] private Transform[] waypoints; // Las localizaciones donde hara un recorrido de patrulla
    private int totalWaypoints;
    [SerializeField] private int nextPoint;

    // ATAQUE - Variables

    private float timeBetweenAttacks = 2f;
    private bool canAttack;
    private float upAttackForce = 15f;
    private float forwardAttackForce = 18f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = false;
    }

    private void Update() // Se movera hacia el destino
    {
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);

        if (!playerInVisionRange && !playerInAttackRange)
        {
            Patrol();
        }

        if (playerInVisionRange && !playerInAttackRange)
        {
            Chase();
        }

        if (playerInVisionRange && playerInAttackRange)
        {
            Attack();
        }

    }

    private void Patrol()
    {
        

        if (Vector3.Distance(transform.position, waypoints[nextPoint].position) < 2.5f)
        {
            nextPoint++;

            if (nextPoint == totalWaypoints)
            {
                nextPoint = 0;

            }

            transform.LookAt(waypoints[nextPoint].position);
        }

        _agent.SetDestination(waypoints[nextPoint].position);
    }

    private void Chase()
    {
        _agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void Attack()
    {
        _agent.SetDestination(transform.position);
        _animator.SetTrigger("Attack_S");

        _animator.SetInteger("Attack_type_TS", Random.Range(1, 3));
        _animator.SetTrigger("Attack_TS");

        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCoolDown());
        }
    }
    public void TakeDamage()
    {
        slimeLives--;
   
        if (slimeLives <= 0)
        {
           _animator.SetBool("isGameOver_S",true);
            _agent.SetDestination(transform.position); //se queda en el sitio
            Destroy(gameObject, 3);
        }
    }

    public void TakeDamageTurtle()
    {
        turtleLives--;

        if (turtleLives <= 0)
        {
            _animator.SetBool("isGameOver_TS", true);
            _agent.SetDestination(transform.position); //se queda en el sitio
            Destroy(gameObject, 3);
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            _playerController.TakeDamage();
        }
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        // Esfera de visi�n
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // Esfera de ataque
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
