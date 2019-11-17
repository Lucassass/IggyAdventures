using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    public float reSpawnTime = 2.0f;
    private float timeLeft;
    private bool gotHit;
    private bool respawn;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        respawn = false;
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
      
        if(timeLeft <= 0 && respawn)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "play";
            respawn = false;
        }
        if (gotHit)
        {
            anim.SetBool("isTouched", true);
            StartCoroutine(Pause(3.0f));
            gotHit = false;
            
        }
    }
    public IEnumerator Pause(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "wayback";
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("isTouched", false);
        respawn = true;
        timeLeft = reSpawnTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        gotHit = true;
    }
}

