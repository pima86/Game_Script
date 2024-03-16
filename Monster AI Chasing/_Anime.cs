using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Start_Anim(string name, bool bo)
    {
        anim.SetBool(name, bo);
    }

    public float Play_Anim(string name)
    {
        anim.Play(name, 0, 0);

        return anim.GetCurrentAnimatorClipInfo(0).Length;
    }
    
}
