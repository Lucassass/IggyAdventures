using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    // Start is called before the first frame update

    public float boost = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<Rigidbody2D>();
        p.gravityScale = -1;
        p.AddForce(new Vector2(0f, boost));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<Rigidbody2D>();
        p.gravityScale = 1;
    }
}
