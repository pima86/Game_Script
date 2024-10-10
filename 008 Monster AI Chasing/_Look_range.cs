using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_range : MonoBehaviour
{
    public string target_tag;

    Search_target search_targer;
    Obj_Control obj_control;
    Anime anime;

    private void Awake()
    {
        search_targer = GetComponent<Search_target>();
        obj_control = GetComponentInParent<Obj_Control>();
    }

    private void Start()
    {
        anime = obj_control.anime;
    }

    Collider obj;
    private void Update()
    {
        if (!anime.GetBool("isAttack"))
        {
            obj = search_targer.short_enemy;

            if (obj != null)
                obj_control.transform.LookAt(obj.transform);
        }
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
        if (obj_control.tag == "Die" || anime.GetBool("isAttack"))
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

        if(obj != null)
            obj.GetComponent<Obj_Control>().HP -= obj_control.power;

        yield return new WaitForSeconds(time / 2f);
        anime.SetBool("isAttack", false);
    }
}
