using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    public void Die() {
        anim.SetTrigger("Tackled");
    }
}
