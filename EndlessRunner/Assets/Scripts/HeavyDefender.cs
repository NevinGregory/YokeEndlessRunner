using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyDefender : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Tackled()
    {
        anim.SetTrigger("Tackled");
    }
}
