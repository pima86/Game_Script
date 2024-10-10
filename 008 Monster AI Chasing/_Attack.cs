using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    /*
     * 사거리 안에 들어온 적을 향해 공격 애니메이션을 출력하거나
     * 없다면 Idle 애니메이션을 출력합니다.
     */

    Obj_Control control;
    Search_target enemy;
    Anime anime;

    public string target_tag;

    private void Start()
    {
        control = GetComponentInParent<Obj_Control>();
        enemy = control.enemy;
        anime = control.anime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (anime.GetBool("isAttack"))
            return;

        if (other.tag == target_tag)
            StartCoroutine(Att());
    }

    private void OnTriggerExit(Collider other)
    {
        if (control.tag == "Die" || anime.GetBool("isAttack"))
            return;

        if (other.tag == target_tag)
        {
            anime.Play_Anim("Idle");
            StopAllCoroutines();
        }
    }

    IEnumerator Att()
    {
        float time = anime.Play_Anim("Default_Attack");

        anime.SetBool("isAttack", true);
        yield return new WaitForSeconds(time / 2f);

        enemy.short_enemy.GetComponent<Obj_Control>().HP -= control.power;

        yield return new WaitForSeconds(time / 2f);
        anime.SetBool("isAttack", false);
    }
}
