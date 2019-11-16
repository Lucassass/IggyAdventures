using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGravity : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 movespeed;
    //public float movex = 5;
    

    void Start()
    {
        //movespeed = new Vector2(2.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<Rigidbody2D>();
        
        p.velocity = movespeed;
    }
}
