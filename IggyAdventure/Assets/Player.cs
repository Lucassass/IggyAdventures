using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float jumpHeight = 4f;
	[SerializeField] private float moveSpeed = 2f;
	private Rigidbody2D m_Rigidbody2D;


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
		}


		if (Input.GetKeyDown(KeyCode.D))
		{
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
		}


		if (Input.GetKeyDown(KeyCode.A))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
		}
	}
}
