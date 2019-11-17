using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFriend : MonoBehaviour
{

    // Update is called once per frame
    public Animator anim;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("candyFree", true);

    }
}
