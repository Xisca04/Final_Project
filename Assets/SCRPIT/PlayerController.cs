using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player Controller

    // Movement
    private float verticalInput; 
    private float moveSpeed;

    // Speed
    private float walkSpeed = 4f;
    private float runSpeed= 6.5f;
    private float jumpForce = 10f;
    public float mouseSensitivity;

    [SerializeField] private bool isOnTheGround;
    private Rigidbody _rigidbody;
    private Animator _animator;

    // Powerups
    public bool hasPowerupLife;
    public int lives = 3;
    public float timer = 0;

    // UI
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI _timer;
    public GameObject winPanel;
    public int Counter;
   
    // Audio
    public AudioClip[] collectables;
    public AudioClip[] attackSounds;
    public AudioClip errorGem;
    public ParticleSystem dirtParticle;
    
    private AudioSource _audioSource;
    private AudioSource _audioAttack;
    [SerializeField] private BoxCollider swordCollider;
    [SerializeField] private GameOver _gameOver;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();  
        _audioSource = GetComponent<AudioSource>();
        _gameOver = FindObjectOfType<GameOver>();
        
        winPanel.SetActive(false);
        swordCollider.enabled = false;
        
    }
    

    private void Update()
    {
        //  Time
        CountDown();

        Movment();

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Left botton down
        {
            Attack();
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround) 
        {
            Jump();
        }

        dirtParticle.Play();
    }

    private void OnCollisionEnter(Collision otherCollider) // Collider ground
    {
        if (otherCollider.gameObject.Equals("Ground"))
        {
            isOnTheGround = true;
        }
    }

    private void Movment()
    {
       verticalInput = Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput); // right,horizontal

        float mouseX = Input.GetAxis("Mouse X"); // mouse rotation
                                                 
        transform.Rotate(Vector3.up, mouseSensitivity * mouseX * Time.deltaTime);

        if (verticalInput != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && TWOstaminaMaria.instance.hasStamina)
            {
                Run();
            }
            else
            {
                Walk();
            }
        }
        else
        {
            Idle();
        }
    }

    private void Idle()
    {
        _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        TWOstaminaMaria.instance.RegenStamina(15);
        dirtParticle.Stop();
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        _animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        TWOstaminaMaria.instance.RegenStamina(15);
        
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        _animator.SetFloat("Speed", 1f, 0.1f,Time.deltaTime); 
        TWOstaminaMaria.instance.UseStamina(40);
        
    }
    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        dirtParticle.Stop();
    }

    private void Attack()
    {
        _animator.SetInteger("Attack_type", Random.Range(1, 3));
        _animator.SetTrigger("Attack");
        dirtParticle.Stop();
        swordCollider.enabled = true;
        StartCoroutine("TimeSwordCollider");
        ChooseRandomSFX(attackSounds);
    }
    private IEnumerator TimeSwordCollider() // Actives the sword collider 
    {
        yield return new WaitForSeconds(1);
        swordCollider.enabled = false;
    }

    public void TakeDamage()
    {
        if (gameObject.CompareTag("Slime"))
        {
            lives--;
            livesText.text = $"{lives}";
        }
        else if(gameObject.CompareTag("Turtle Shell"))
        {
            lives -= 2;
            livesText.text = $"{lives}";
        }
    
        if (lives <= 0)
        {
            _animator.SetBool("Die",true);
            _gameOver.GameOverLevels();
        }
    }


    private void ChooseRandomSFX(AudioClip[] sounds)
    {
      int randomIdx = Random.Range(0, sounds.Length);
      _audioSource.PlayOneShot(sounds[randomIdx], 1);
    }


    // Collectables

    private void GetCoins(Collider other) 
    {
        Destroy(other.gameObject);
        Counter++;
        counterText.text = $"{Counter}";
        _audioSource.PlayOneShot(collectables[1]);

    }

    private void GetPowerUp(Collider other)
    {
        Destroy(other.gameObject);
        lives++;
        livesText.text = $"{lives}";
        hasPowerupLife = true;
        _audioSource.PlayOneShot(collectables[2]);
    }

    public void GetGemFinish(Collider other)
    {
        if (Counter >= 10) // Level 1
        {
            Destroy(other.gameObject);
            winPanel.SetActive(true);
            timer = 60;
            _audioSource.PlayOneShot(collectables[3]);
        }
        else
        {
            _audioSource.PlayOneShot(errorGem);
        }

        if(Counter >= 12)  // Level 2
        {
            Destroy(other.gameObject);
            winPanel.SetActive(true);
            timer = 120;
            _audioSource.PlayOneShot(collectables[3]);
        }
        else
        {
            _audioSource.PlayOneShot(errorGem);
        }
    }

    private void GetHourGlass(Collider other)
    {
        Destroy(other.gameObject);
        _audioSource.PlayOneShot(collectables[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            GetCoins(other);
        }
        else if (other.gameObject.tag.Equals("Power Up"))
        {
            GetPowerUp(other);
        }
        else if (other.gameObject.tag.Equals("Finish Level"))
        {
            GetGemFinish(other);
        }
        else if (other.gameObject.tag.Equals("Timer"))
        {
            GetHourGlass(other);
            timer += 10;
        }
    }

    private void CountDown() // Timer
    {
        timer -= Time.deltaTime;
        _timer.text = "" + timer.ToString("f1");

        if (timer <= 0)
        {
            timer = 0;
        }
    }
}
