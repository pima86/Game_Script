```ruby
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Fallow_target : MonoBehaviour
{
    Rigidbody rigid;
    Transform target_trans;
    NavMeshAgent nav;
    bool move;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
    }

    public void Move(Transform transform, bool bo)
    {
        target_trans = transform;
        move = bo;
    }

    private void Update()
    {
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

```
