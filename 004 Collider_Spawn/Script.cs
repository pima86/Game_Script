using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mob_Spawn : MonoBehaviour
{
    public GameObject rangeObject;
    public float spawnTime;
    BoxCollider rangeCollider;

    public float not_mobzone_x;
    public float not_mobzone_z;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        Vector3 main_pos = GameManager.Inst.character[0].transform.position;

        float x = 0;
        if(Random.Range(0, 2) == 0 && main_pos.x - not_mobzone_x >= -50F)
            x = Random.Range(-50f, main_pos.x - not_mobzone_x);
        else if(main_pos.x + not_mobzone_x <= 50F)
            x= Random.Range(main_pos.x + not_mobzone_x, 50f);

        float z = 0;
        if (Random.Range(0, 2) == 0 && main_pos.z - not_mobzone_z >= -50F)
            z = Random.Range(-50f, main_pos.z - not_mobzone_z);
        else if (main_pos.z + not_mobzone_z <= 50F)
            z = Random.Range(main_pos.z + not_mobzone_z, 50f);


        Vector3 respawnPosition = originPosition + new Vector3(x, 0, z);
        return respawnPosition;
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Mob_Pool.Inst.Pool.Get();

            instantCapsul.transform.position = Return_RandomPosition();

            yield return new WaitForSeconds(0.1f);

            instantCapsul.tag = "Mob";
            instantCapsul.layer = 7;
        }
    }
}
