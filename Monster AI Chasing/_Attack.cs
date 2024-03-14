using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Search_target enemy;
    Fallow_target fallow_target;

    //공격 사거리
    BoxCollider range;

    public string target_tag;

    //몬스터입니까?!
    public bool ismob;
    Anime anime;

    private void Awake()
    {
        enemy = GetComponent<Search_target>();
        fallow_target = GetComponent<Fallow_target>();

        if(TryGetComponent<Anime>(out Anime a)) anime = a;
    }

    private void Update()
    {
        Move();
    }

    bool attack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target_tag)
        {
            fallow_target.Move(enemy.short_enemy.transform, false);

            attack = true;
            StartCoroutine(Att());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == target_tag)
        {
            anime.Play_Anim("Idle");

            attack = false;
            StopAllCoroutines();
        }
    }

    IEnumerator Att()
    {
        while (attack)
        {
            yield return new WaitForSeconds(anime.Play_Anim("Default_Attack"));
        }
    }

    private void Move()
    {
        if (enemy.short_enemy != null)
        {
            fallow_target.Move(enemy.short_enemy.transform, true);

            if (ismob)
            {
                anime.Start_Anim("isMove", true);
            }

        }
    }
}
