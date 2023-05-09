using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    private UnityEngine.AI.NavMeshAgent _agent;

    private float visionRange = 3.5f;
    private float attackRange = 2f;

    private bool playerInVisionRange;
    private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    // PATRULLA - Variables

    [SerializeField] private Transform[] waypoints; // Las localizaciones donde hara un recorrido de patrulla
    private int totalWaypoints;
    private int nextPoint;

    // ATAQUE - Variables

    private float timeBetweenAttacks = 2f;
    private bool canAttack;
    private float upAttackForce = 15f;
    private float forwardAttackForce = 18f;

    private void Awake()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
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

        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCoolDown());
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
