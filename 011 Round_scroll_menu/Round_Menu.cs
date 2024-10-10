using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room_Menu : MonoBehaviour
{
    [Header("드래그 회전 속도")]
    public float rotate_speed;

    [Header("자식 오브젝트들")]
    [SerializeField] GameObject[] obj;
    [SerializeField] Transform target;

    //해당 오브젝트의 Rotate
    //이미지의 하이라이키를 조정하는 용도로 사용함.
    float this_z;

    private void Update()
    {
        Obj_LookAt();
        Sort();
    }

    public void OnClick()
    {
        Debug.Log("클릭");
    }

    #region 드래그를 통한 메뉴 회전
    Vector3 mousePos;
    Vector3 rotation;
    public void OnBeginDrag()
    {
        mousePos = Input.mousePosition;
    }

    public void OnDrag()
    {
        Vector3 offset = Input.mousePosition - mousePos;

        rotation.z = -(offset.y) * Time.deltaTime * rotate_speed;
        transform.Rotate(rotation);

        if (rotation.z > 0) updown = true;
        else updown = false;

        mousePos = Input.mousePosition;

    }

    public void OnEndDrag()
    {
        mousePos = Vector3.zero;
        rotation = Vector3.zero;
    }
    #endregion
    #region 정렬
    bool updown;

    //오브젝트 LookAt 반복문
    void Obj_LookAt()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].transform.LookAt(target.position);
        }
    }

    //이미지 하이라이키 조정
    void Sort()
    {
        float temp = Mathf.Abs(this_z - transform.eulerAngles.z);
        
        if (temp / 45f > 1f)
        {
            this_z = Mathf.Abs(transform.eulerAngles.z);


            int addrass = Mathf.FloorToInt(transform.eulerAngles.z / 45);

            /*
             * OnDrag()에서 어느 방향으로 드래그 중인지 updown 변수로 받아와
             * 그에 맞는 순서대로 이미지들의 하이라이키를 재조정해줍니다.
             */
            if (updown)
            {
                Debug.Log("들어옴");
                //내릴때
                addrass++;

                for (int i = addrass; -(i) + addrass < obj.Length; i--)
                {
                    int n = 0;
                    if (i < 0)
                        n = obj.Length + i;
                    else n = i;

                    //Debug.Log("i가 " + i + "일 때 n의 값은 " + n + "입니다.");

                    if (n != addrass) obj[n].transform.SetAsFirstSibling();
                }
            }
            else 
            {
                //올릴때
                addrass --;

                for (int i = addrass; i <= obj.Length + addrass; i++)
                {
                    int n = 0;
                    if (i >= obj.Length)
                        n = i - obj.Length;
                    else n = i;

                    if (n != addrass) obj[n].transform.SetAsFirstSibling();
                }
            }
        }
    }

    #endregion
}
