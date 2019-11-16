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
	void onTriggerEnter2D(Collision2D collider)
	{
        var p = collider;
        p.gameObject.GetComponent<Player>().SetSpawnLocation((this.gameObject.transform.position));
	}
}