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
    //[SerializeField] private PostProcessing _postProcessing;

    // References
    private NavMeshAgent _agent;
    private Animator _animator;

    //Lives
    private int slimeLives = 1;
    private int turtleLives = 2;
    //*** [SerializeField] private int enemiesLives;
   
    // Vision
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

    // Audio
    public AudioSource _audioSourceSlime;
    public AudioSource _audioSourceTurtle;
    public AudioClip slimeAttack; 
    public AudioClip turtleAttack;
    public AudioClip slimeDeath;
    public AudioClip turtleDeath;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        //_postProcessing = FindObjectOfType<PostProcessing>();
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = false;
        _audioSourceSlime = GetComponent<AudioSource>();
        _audioSourceTurtle = GetComponent<AudioSource>();
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
        _audioSourceSlime.PlayOneShot(slimeAttack);

        _animator.SetInteger("Attack_type_TS", Random.Range(1, 3));
        _animator.SetTrigger("Attack_TS");
        _audioSourceTurtle.PlayOneShot(turtleAttack);

       // _postProcessing.StartCoroutine(Desactive());

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
            _audioSourceSlime.PlayOneShot(slimeDeath);
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
            _audioSourceTurtle.PlayOneShot(turtleDeath);
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
