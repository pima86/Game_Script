using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCam : MonoBehaviour
{
    [SerializeField] Camera cam;

    [Header("타일맵 정보")]
    [SerializeField] DivideSpace divideSpace;

    Vector3 touchPos = Vector3.zero;

    [Header("ZoomSpeed")]
    [SerializeField] float touchZoomSpeed;
    [SerializeField] float mouseWheelSpeed;

    [Header("Size")]
    [SerializeField] float maxSize;
    [SerializeField] float minSize;

    bool desktopMouseDown = false;
    void Update()
    {
        if (TurnManager.Inst.turn == TurnManager.Turn.Main)
        {
            //모바일 터치
            if (SystemInfo.deviceType == DeviceType.Handheld)
                MoblieTouch();

            //데스크탑 터치
            else
                DesktopTouch();
        }
    }

    void MoblieTouch()
    {
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            if (Input.touchCount == 1)
            {
                Vector3 pos = cam.ScreenToWorldPoint(Input.touches[0].position);

                if (Input.GetTouch(0).phase == TouchPhase.Began) 
                    touchPos = pos;
                else if(Input.GetTouch(0).phase == TouchPhase.Ended) 
                    touchPos = Vector3.zero;
                else 
                    OnPointerDown(cam.ScreenToWorldPoint(Input.touches[0].position));
            }
            else if (Input.touchCount == 2)
            {
                Touch touch_1 = Input.touches[0];
                Touch touch_2 = Input.touches[1];

                //이전 프레임의 터치 좌표를 구한다.
                Vector2 t1PrevPos = touch_1.position - touch_1.deltaPosition;
                Vector2 t2PrevPos = touch_2.position - touch_2.deltaPosition;

                //이전 프레임과 현재 프레임 움직임 크기를 구함.
                float prevDeltaMag = (t1PrevPos - t2PrevPos).magnitude;
                float deltaMag = (touch_1.position - touch_2.position).magnitude;

                //두 크기값의 차를 구해 줌 인/아웃의 크기값을 구한다.
                float deltaMagDiff = prevDeltaMag - deltaMag;

                Camera.main.orthographicSize += deltaMagDiff * touchZoomSpeed;
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minSize, maxSize);
            }
        }
    }

    void DesktopTouch()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                touchPos = pos;
                desktopMouseDown = true;
            }
            else if (Input.GetMouseButton(0) && desktopMouseDown)
            {
                OnPointerDown(pos);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                desktopMouseDown = false;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel") * mouseWheelSpeed;
        if (cam.orthographicSize <= minSize && scroll > 0) cam.orthographicSize = minSize;
        else if (cam.orthographicSize >= maxSize && scroll < 0) cam.orthographicSize = maxSize;
        else cam.orthographicSize -= scroll * 0.5f;
    }

    public void OnPointerDown(Vector3 pos)
    {
        Vector3 distance = cam.transform.position + (touchPos - pos);

        if(distance.x < 0) 
            distance = new Vector3(0, distance.y, distance.z);
        else if(distance.x > divideSpace.totalWidth) 
            distance = new Vector3(divideSpace.totalWidth, distance.y, distance.z);

        if (distance.y < 0) 
            distance = new Vector3(distance.x, 0, distance.z);
        else if (distance.y > divideSpace.totalHeight) 
            distance = new Vector3(distance.x, divideSpace.totalHeight, distance.z);

        cam.transform.position = new Vector3(distance.x, distance.y, -10);
    }
}
