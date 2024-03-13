```ruby
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search_target : MonoBehaviour
{
    public float radius = 0f;

    public LayerMask layer;
    public Color color;

    public Collider[] colliders;
    public Collider short_enemy;

    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }
            if (short_enemy == null)
                short_enemy = colliders[0];
        }
        else
            short_enemy = null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

```
