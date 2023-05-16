using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float verticalInput; //movment
    private float moveSpeed;
    public float turnSpeed = 60f; //speed
    public float walkSpeed = 8f;
    public float runSpeed= 20f;

    public float jumpForce = 10f;

    public float mouseSensitivity;

    [SerializeField] private bool isOnTheGround;
    private Rigidbody _rigidbody;
    private Animator _animator;

    public bool hasPowerupLife;
    public int lives = 3;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI livesText;
    public float timer = 0;
    public TextMeshProUGUI _timer;
    public GameObject winPanel;

    [SerializeField] private BoxCollider swordCollider;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked; //press [esc] to exit the mode  

        winPanel.SetActive(false);
    }
    

    private void Update()
    {
        //  Time
        CountDown();


        Movment();

        if (Input.GetKeyDown(KeyCode.Mouse0)) //left botton down
        {
            Attack();
        }
        else
        {
            swordCollider.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround ) //salto con el espacio y no podré saltar si es gameover(MUERTO)
        {
            Jump();
        }

        SaltoEscena();
    }

    private void OnCollisionEnter(Collision otherCollider) //collider ground
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }
    }
   
    private void Movment()
    {
       
        verticalInput = Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * verticalInput); //right,horizontal

        float mouseX = Input.GetAxis("Mouse X"); //mouse rotation
                                                 
        transform.Rotate(Vector3.up, mouseSensitivity * mouseX * Time.deltaTime);

        if (!(verticalInput != 0))
        {
            Idle();
        }
        else if (!Input.GetKey(KeyCode.LeftShift)) 
        {
            Walk();
        }
        else 
        {
            Run();
        }
    }

    private void Idle()
    {
        _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        _animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        _animator.SetFloat("Speed", 1f, 0.1f,Time.deltaTime); //adding the smooth
    }
    private void Jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       
    }

    private void Attack()
    {
        _animator.SetInteger("Attack_type", Random.Range(1, 3));
        _animator.SetTrigger("Attack");

        swordCollider.enabled = true;
    }

    public int Counter;

    private void GetCoins(Collider other) // Destroy the collectable
    {
        Destroy(other.gameObject);
        Counter++;
        counterText.text = $"Coins: {Counter}";

    }

    private void GetPowerUp(Collider other)
    {
        Destroy(other.gameObject);
        lives++;
        livesText.text = $"Lives: {lives}";
        hasPowerupLife = true;
    }

    private void GetGem(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log($"Has conseguido la gema. yeeeeeey");
    }

    public void GetGemFinish(Collider other)
    {
       // if (2100 monedas pasas)
        Destroy(other.gameObject);
        winPanel.SetActive(true);

        SaltoEscena();
    }

    private void GetHourGlass(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Coin"))
        {
            GetCoins(other);
        }
        else if (other.gameObject.tag.Contains("Power Up"))
        {
            GetPowerUp(other);
        }
        else if (other.gameObject.tag.Contains("Gem"))
        {
            GetGem(other);
        }
        else if (other.gameObject.tag.Contains("Finish Level"))
        {
            GetGemFinish(other);
        }
        else if (other.gameObject.tag.Contains("Timer"))
        {
            GetHourGlass(other);
            timer += 10;
        }
    }

    private void CountDown()
    {
        /*
        yield return new WaitForSeconds(0.3f);
        
        for (int i = 300; i <= 0; i++)
        {
            _timer.text = $"{timer}";
            timer++;
        }
        */
        timer -= Time.deltaTime;
        _timer.text = "" + timer.ToString("f1");

        if (timer <= 0)
        {
            timer = 0;
        }
    }

    public void SaltoEscena()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
