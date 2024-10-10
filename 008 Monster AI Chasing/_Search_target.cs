using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_target : MonoBehaviour
{
    /*
     * 가장 가까운 대상을 찾아서 요청하는 스크립트에게 전송합니다.
     */

    public float radius = 0f;

    public LayerMask layer;
    public Color color;

    public Collider[] colliders;
    public Collider short_enemy;

    void Update()
    {
        colliders = null;
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length > 0)
        {
            short_enemy = colliders[0];

            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                if (col.gameObject == gameObject)
                    continue;

                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }
        }
        else if(colliders.Length == 0)
            short_enemy = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
