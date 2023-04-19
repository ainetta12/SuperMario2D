using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 5.5f;
    public float jumForce = 3f;
    int contadorCoin;
    public Text contadorTexto;

    string texto = "Hello World";

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    private Moneda moneda;
    private Flag flag;
    public Animator anim;

    float horizontal;
   
    GameManager gameManager;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Transform attackHitBox;
    public float attackRange;
    public LayerMask enemyLayer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sensor = GameObject.Find ("GroundSensor").GetComponent<GroundSensor>();
        //moneda = GameObject.Find ("Moneda").GetComponent<Moneda>();

        //Busscamos el objeto GameManager y lo asignamos asignamos a la variable del GameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      
        playerHealth = 10;
        Debug.Log(texto);

        contadorCoin = 0;
    }

    // Update is called once per frame
    void Update()
    
    {
        if(gameManager.isGameOver == false)
        {
              horizontal = Input.GetAxis("Horizontal");
        }
        //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;

        if(horizontal < 0)
        {
            //spriteRenderer.flipX = true; 
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("IsRunning", true);
        }

        else if(horizontal > 0)
        {
             //spriteRenderer.flipX = false;
             transform.rotation = Quaternion.Euler(0, 0, 0);
             anim.SetBool("IsRunning", true);
        }
        else
        {
             anim.SetBool("IsRunning", false);
        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
        if(Input.GetKeyDown(KeyCode.F) && gameManager.canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }


        
    }


    void FixedUpdate() 
    {
        rBody.velocity = new Vector2 (horizontal * playerSpeed, rBody.velocity.y);
    }

    void Attack ()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackHitBox.position, attackRange, enemyLayer);

        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            Destroy(enemiesInRange[i].gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionMoneda")
        {
            Debug.Log("Mario muerto");
            Destroy(collision.gameObject);
            Moneda moneda = collision.gameObject.GetComponent<Moneda>();
            moneda.Die();
            contadorCoin++;
            contadorTexto.text = "coin " + contadorCoin.ToString();
            Debug.Log(contadorCoin);

        }

        if (collision.gameObject.tag == "CollisionFlag")
        {
            Debug.Log("Mario muerto");
            Flag flag = collision.gameObject.GetComponent<Flag>();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Colin")
        {
           gameManager.AddCoin();
           Destroy(collider.gameObject);
        }

         if (collider.gameObject.tag == "PowerUp")
        {
           gameManager.canShoot = true;
           Destroy(collider.gameObject);
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackRange);
    }
}
