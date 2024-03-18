using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Dmg_Control : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    public float destroy_time;
    public float speed;
    public TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
        //GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, obj.transform.position);
    }

    public void Request_Return(Vector3 pos, int dmg)
    {
        GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, pos) + new Vector2(0, 100);
        tmp.text = string.Format("{0:#,###}", dmg);
        Invoke("Return_pool", destroy_time);
    }

    void Return_pool()
    {
        Pool.Release(this.gameObject);
    }
}
