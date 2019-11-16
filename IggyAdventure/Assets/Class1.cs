using UnityEngine;
using System.Collections;

public class UpdateSpawn : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()

	{
	}

	// Update is called once per frame
	void Update()
	{

	}
	void onTriggerEnter2D()
	{
	Player.setSpawn(this.gameObject.tranform.position);
	}
}
