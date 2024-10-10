using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Dmg_Pool : MonoBehaviour
{
    public static Dmg_Pool Inst;

    public int defaultCapacity = 10;
    public int maxPoolSize = 15;
    public GameObject Prefab;

    public IObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        if (Inst == null)
            Inst = this;
        else
            Destroy(this.gameObject);


        Init();
    }

    #region 오브젝트 풀링
    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
        OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);

        // 미리 오브젝트 생성 해놓기
        for (int i = 0; i < defaultCapacity; i++)
        {
            Dmg_Control obj = CreatePooledItem().GetComponent<Dmg_Control>();
            obj.Pool.Release(obj.gameObject);
        }
    }

    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(Prefab, transform);
        poolGo.GetComponent<Dmg_Control>().Pool = this.Pool;
        return poolGo;
    }

    // 사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
        //poolGo.GetComponent<Dmg_Control>().Request_Return();
    }

    // 반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
    #endregion
}
