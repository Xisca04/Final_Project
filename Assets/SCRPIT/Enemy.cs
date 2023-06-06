using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Enemy : MonoBehaviour
{
    // Both enemies

    // Script communication
    [SerializeField] private Transform player;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PostProcessing _postProcessing;

    // References
    private NavMeshAgent _agent;
    private Animator _animator;

    //Lives
    [SerializeField] private int enemiesLives;
   
    // Vision
    private float visionRange = 3.5f;
    private float attackRange = 1.5f;
    [SerializeField] private bool playerInVisionRange;
    [SerializeField] private bool playerInAttackRange;
    [SerializeField] private LayerMask playerLayer;

    // PATRULLA - Variables
    [SerializeField] private Transform[] waypoints; // Las localizaciones donde hara un recorrido de patrulla
    private int totalWaypoints;
    [SerializeField] private int nextPoint;

    // ATAQUE - Variables
    private float timeBetweenAttacks = 4f;
    private bool canAttack;

    // Audio
    public AudioSource _audioSource;
    public AudioClip enemyAttack; 
    public AudioClip enemyDeath;

    public bool isRed;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _postProcessing = FindObjectOfType<PostProcessing>();
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = false;
        _audioSource = GetComponent<AudioSource>();
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
        if (isRed)
        {
            _agent.SetDestination(transform.position);
            _animator.SetTrigger("Attack_S");
           
        }
        else
        {
            _animator.SetInteger("Attack_type_TS", Random.Range(1, 3));
            _animator.SetTrigger("Attack_TS");
            
            
        }
       
      
        _audioSource.PlayOneShot(enemyAttack);

        StartCoroutine(_postProcessing.Active());

        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCoolDown());
        }
    }

    public void TakeDamage()
    {
        enemiesLives--;
   
        if (enemiesLives <= 0)
        {
            if (isRed)
            {
                _animator.SetBool("isGameOver_S", true);
            }
            else
            {
                _animator.SetBool("isGameOver_TS", true);
            }
            
            StartCoroutine(_postProcessing.Desactive());
            _audioSource.PlayOneShot(enemyDeath);
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
        // Vision sphere
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        // Attack sphere
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
