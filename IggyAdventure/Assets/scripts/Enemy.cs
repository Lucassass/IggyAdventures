using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float timeToReSpawn = 3.0f;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeToReSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
            this.GetComponent<EnemyPathing>().speed = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.TakeDamage(1);
        }
    }
    public void SetRespawnTime()
    {
        timeLeft = timeToReSpawn;
    }
}

