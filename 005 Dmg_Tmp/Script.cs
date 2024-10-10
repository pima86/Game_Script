using TMPro;
using UnityEngine;

public class Dmg_Control : MonoBehaviour
{
    public float destroy_time;

    [Header("컴포넌트")]
    public Pool_Control pool;
    public TextMeshPro tmp;

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
        //UGUI
        //GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, obj.transform.position);
    }

    public void Request_Return(Vector3 pos, int dmg)
    {
        transform.position = pos + new Vector3(0, 0.5f, 0);
        //UGUI
        //GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, pos) + new Vector2(0, 100); 
        
        tmp.text = string.Format("{0:#,###}", dmg);
        Invoke("Return_pool", destroy_time);
    }

    void Return_pool()
    {
        pool.Return_pool();
    }
}
