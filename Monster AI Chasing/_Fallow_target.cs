using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Fallow_target : MonoBehaviour
{
    /*
     * 입력받은 Transform으로 Nav를 통해 이동합니다.
     */

    Rigidbody rigid;
    NavMeshAgent nav;
    Anime anime;

    Transform target_trans;
    bool move;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anime = GetComponent<Anime>();
    }

    public void Move(Transform transform, bool bo)
    {
        target_trans = transform;
        move = bo;

        anime.SetBool("isMove", bo);
    }

    private void Update()
    {
        if(nav.enabled)
            Fallow_Target();
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void Fallow_Target()
    {
        nav.isStopped = !move;

        if (move)
            nav.SetDestination(target_trans.position);
        else
            nav.velocity = Vector3.zero;
    }
}
