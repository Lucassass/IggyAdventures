using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject bullet;
	[SerializeField] private float jumpHeight = 4f;
	[SerializeField] private float moveSpeed = 2f;
	private int direction;
	public int currentHealth;
	private int maxHealth = 4;

	// Start is called before the first frame update
	void Start()
    {
        currentHealth = maxHealth;
    }

	// Update is called once per frame
	void Update()
	{
		IsDeath();
		if (Input.GetKey(KeyCode.R))
		{
			Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
		}


		if (Input.GetKeyDown(KeyCode.D))
		{
			direction = 1;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
		}


		if (Input.GetKeyDown(KeyCode.A))
		{
			direction = -1;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			public static Object Instasiate(Bullet original, new Vector2(direction, 2);
		}
	}
		void IsDeath()
	{
		if (currentHealth == 0) {
			Destroy(gameObject);
		}
	}
}
