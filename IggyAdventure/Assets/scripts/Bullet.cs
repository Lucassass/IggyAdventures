using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //chain the player prefab to the bullet prefab
    public GameObject player;
    public int maxTravelDistance = 20;
    public int speed = 20;
    private int dir;
    private float surviveTime = 0.5f;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the directon the player is facing when shooting
        dir = Player.GetDirection();
        timeLeft = surviveTime;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * dir, 0);

        //Destroying the obj when they are more than x away from the player. Using math abs to do it in either direaction
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        //obj.gameObject.GetComponent<Collider2D>().isTrigger = false;
        //Enemy enemy = obj.gameObject.GetComponent<Enemy>();
        //enemy.SetRespawnTime();
        //this.GetComponent<EnemyPathing>().speed = 0;
        //if (obj.gameObject.CompareTag("Enemy")) { Destroy(obj.gameObject); }
        
    }
}



