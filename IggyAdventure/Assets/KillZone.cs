using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("vdsbhv");
        var p = collision.gameObject.GetComponent<Player>();
        if (p != null)
        {
            p.transform.position = p.spawnLocation;
        }
        Debug.Log("dead");
    }
}