using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool_Manager : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    #region 오브젝트 풀링
    public IObjectPool<GameObject> Pool { get; private set; }
    public GameObject prefab;

    public int defaultCapacity = 5;
    public int maxPoolSize = 5;

    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);

        // 미리 오브젝트 생성 해놓기
        for (int i = 0; i < defaultCapacity; i++)
        {
            Pool_Control obj = CreatePooledItem().GetComponent<Pool_Control>();
            obj.Pool.Release(obj.gameObject);
        }
    }

    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(prefab, transform);
        poolGo.GetComponent<Pool_Control>().Pool = this.Pool;
        return poolGo;
    }

    // 사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
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
