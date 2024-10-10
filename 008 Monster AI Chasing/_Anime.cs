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

    public void SetBool(string name, bool bo)
    {
        anim.SetBool(name, bo);
    }

    public bool GetBool(string name) { return anim.GetBool(name); }

    public float Play_Anim(string name)
    {
        anim.Play(name, 0, 0);

        return anim.GetCurrentAnimatorClipInfo(0).Length;
    }
}
