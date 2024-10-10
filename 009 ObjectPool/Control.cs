using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool_Control : MonoBehaviour
{
    #region 오브젝트 폴링
    public IObjectPool<GameObject> Pool { get; set; }

    public void Return_pool() //회수하기
    {
        Pool.Release(this.gameObject);
    }
    #endregion
}
