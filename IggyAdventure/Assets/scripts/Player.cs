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
    private Vector2 spawnLocation;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        int isJumping = 0;
        int Movedir = 0;
        Debug.Log(isGrounded);
        IsDeath();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
            isJumping = 1;
        }


        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            Movedir = 1;
        }


        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            Movedir = -1;
        }

        GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed * Movedir, jumpHeight * isJumping);


        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(bullet);
        }
    }
    void IsDeath()
    {
        if (currentHealth == 0)
        {
            transform.position = spawnLocation;
        }
    }
    public static int getDirection()
    {
        return direction;
    }
    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void SetSpawnLocation(Vector2 location)
    {
        this.spawnLocation = location;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
