using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private float jumpHeight = 4f;
    [SerializeField] private float moveSpeed = 2f;
    private static int direction;
    public static int currentHealth;
    private int maxHealth = 4;
    public Vector2 spawnLocation;
    private bool isGrounded;
    private float scale;
    public Animator anim; 

    public bool FlipX { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        currentHealth = maxHealth;
        SetSpawnLocation(this.transform.position);
        scale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //if(this.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.1)
        //isGrounded = true;
        //
        else
        {
            isGrounded = false;
        }
        */
        int isJumping = 0;
        int Movedir = 0;
       

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
            isJumping = 1;
            anim.SetBool("JumpPressed",true);
            anim.SetBool("FirePressed",false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            Movedir = 1;
            this.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetFloat("Speed",1f);
            anim.SetBool("FirePressed",false);
            anim.SetBool("JumpPressed",false);
        }


        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            Movedir = -1;
            this.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetFloat("Speed",1f);
            anim.SetBool("FirePressed",false);
            anim.SetBool("JumpPressed",false);
        }



        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        //GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed * Movedir, jumpHeight * isJumping);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * Movedir, jumpHeight * isJumping), ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(bullet,this.transform.position,Quaternion.identity);
            anim.SetBool("FirePressed",true);
        }

        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            anim.SetFloat("Speed", 0f);  
        }
    }
    public void IsDeath()
    {

            anim.SetBool("Dead", true);
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(Pause(4.0f));
  
    }
    public IEnumerator Pause(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.position = spawnLocation;
        anim.SetBool("Dead", false);
    }
    public static int GetDirection()
    {
        return direction;
    }
    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("Toook damage");
    }
    public void SetSpawnLocation(Vector2 location)
    {
        this.spawnLocation = location;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IsDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
