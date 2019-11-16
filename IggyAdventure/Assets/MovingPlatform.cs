using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
using Platformer.Core;


public class MovingPlatform : MonoBehaviour
{
	PlatformerModel model = Simulation.GetModel<PlatformerModel>();
	public Rigidbody2D rb;
	public Rigidbody2D platFormRb;
	/// <summary>The objects initial position.</summary>
	private Vector2 startPosition;
	/// <summary>The objects updated position for the next frame.</summary>
	private Vector2 newPosition;
	private bool riding;

	/// <summary>The speed at which the object moves.</summary>
	[SerializeField] private int movingTime = 2;
	/// <summary>The maximum distance the object may move in either y direction.</summary>
	[SerializeField] private float toPosition = 1.0f;
	[SerializeField] private float fromPosition = -1.0f;
	private Vector2 to;
	private Vector2 from;

	private void Awake()
	{
		transform.position = new Vector3(3.0f, 0.0f, 0.0f);
	}

	void Start()
	{
		to = new Vector2(toPosition, 0.0f);
		from = new Vector2(fromPosition, 0.0f);
		riding = false; 
		print("Started");
		platFormRb = gameObject.GetComponent<Rigidbody2D>();
		platFormRb.isKinematic = true;

	}


	void FixedUpdate()
	{

		// Moves the GameObject to the left of the origin.
		if (transform.position.x > 3.0f)
		{
			platFormRb.velocity = new Vector2(-1, 0);
		}
		else if (transform.position.x < 3.0f) {
			platFormRb.velocity = new Vector2(1, 0);
		}

		//platFormRb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
		if (riding)
		{
			rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);

		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{

			other.transform.parent = transform;

	}

	void OnTriggerExit2D(Collider2D other)
	{

			other.transform.parent = null;
		

	}
}
