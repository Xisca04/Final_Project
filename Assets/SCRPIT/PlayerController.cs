using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float verticalInput; //movment
    private float moveSpeed;
    public float turnSpeed = 60f; //speed
    public float walkSpeed = 8f;
    public float runSpeed= 20f;

    public float jumpForce = 10f;

    public float mouseSensitivity;

    private bool isOnTheGround;
    private Rigidbody _rigidbody;
    private Animator _animator;

    public bool hasPowerupLife;
    public int lives = 3;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI livesText;
    public int timer = 0;
    public TextMeshProUGUI _timer;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked; //press [esc] to exit the mode

        //  Time

        StartCoroutine(counter());
    }
    private void Update()
    {
        Movment();

        if (Input.GetKeyDown(KeyCode.Mouse0)) //left botton down
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround ) //salto con el espacio y no podr� saltar si es gameover(MUERTO)
        {
            Jump();
        }
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

    private void GetGemFinish(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log($"Has pasado de nivel");
    }

    private void GetHourGlass(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log($"Has conseguido m�s tiempo");
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
        }
    }

    private IEnumerator counter()
    {
        yield return new WaitForSeconds(0.3f);
        
        for (int i = 300; i <= 0; i++)
        {
            _timer.text = $"{timer}";
            timer++;
        }
    }

    /*
    private IEnumerator counter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _timer.text = $"{timer}";
            timer++;
        }
    }
    */
}