using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	//chain the player prefab to the bullet prefab
	public GameObject player;
	public int maxTravelDistance = 5;
	public int speed = 8;
	private int dir;
    // Start is called before the first frame update
    void Start()
    {
		//Getting the directon the player is facing when shooting
		dir = Player.getDirection();
	}

    // Update is called once per frame
    void Update()
    {	
		GetComponent<Rigidbody2D>().velocity = new Vector2(5 * dir, 0);

		//Destroying the obj when they are more than x away from the player. Using math abs to do it in either direaction
		if (System.Math.Abs(player.transform.position.x - transform.position.x) > maxTravelDistance) {
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D obj)
	{
		obj.gameObject.GetComponent<Collider2D>().isTrigger = false;
		EnemyPathing.speed = 0; 
	}
}
