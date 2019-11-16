using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<Rigidbody2D>();
        p.gravityScale = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //p.velocity = new Vector2(0f, 3.0f);
            p.transform.position = p.transform.position + new Vector3(0f, 0.1f, 0f);

        } else if(Input.GetKey(KeyCode.DownArrow))
        {
            p.velocity = new Vector2(0f, -3.0f);
            p.transform.position = p.transform.position - new Vector3(0f, 0.1f, 0f);
        }
        else
        {
            //p.velocity = new Vector2(0f, 0.0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var p = collision.gameObject.GetComponent<Rigidbody2D>();
        p.gravityScale = 1;
    }
}
