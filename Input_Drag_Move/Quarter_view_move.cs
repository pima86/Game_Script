using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Input_Move : MonoBehaviour
{
    private bool isMove;
    private Vector3 destination;

    [SerializeField] TextMeshProUGUI test_TMP;
    Animator animator;
    Rigidbody rigid;

    private void Start()
    {
        character = gameObject.transform;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            Touch();
        else
            Click();

        test_TMP.text = destination.ToString();
        Move();
    }
    #region 터치 관련
    void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit))
            {
                destination = new Vector3(hit.point.x, 0, hit.point.z);
                animator.SetBool("isMove", true);
            }
        }
    }

    void Click()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                destination = new Vector3(hit.point.x, 0, hit.point.z);
                animator.SetBool("isMove", true);
            }
        }
    }
    #endregion
    #region 이동
    Transform character;
    private void Move()
    {
        if (animator.GetBool("isMove"))
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                animator.SetBool("isMove", false);
                return;
            }

            var dir = destination - transform.position;
            character.transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }
    #endregion
}
