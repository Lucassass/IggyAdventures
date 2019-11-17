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
	void OnTriggerEnter2D(Collider2D collider)
	{
        Debug.Log("spawn updated");
        var p = collider;
        p.gameObject.GetComponent<Player>().SetSpawnLocation((this.gameObject.transform.position));
	}
}