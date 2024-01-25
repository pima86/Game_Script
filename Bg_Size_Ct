using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Bg_Size_Ct : MonoBehaviour
{
    public static Bg_Size_Ct Inst { get; private set; }

    #region 변수함
    //배경 스프라이트 렌더러 오브젝트
    [SerializeField] SpriteRenderer Bg_sp;
    //배경으로 쓸 스프라이트 변수
    [SerializeField] Sprite sp;
    #endregion

    private void Awake()
    {
        Inst = this;

        //필요한 함수를 가져와서 호출하기
        Bg_Change_Horizontal(sp);
    }

    #region 메인스크립트
    public void Bg_Change_Horizontal(Sprite sprite) //가로 모드
    {
        Bg_sp.sprite = sprite;

        Bg_sp.transform.localScale = new Vector2(
            Mathf.Ceil(sp.bounds.size.y / UnityEngine.Screen.height * UnityEngine.Screen.width / sp.bounds.size.x),
            Camera.main.orthographicSize * 2 / sp.bounds.size.y);
    }

    public void Bg_Change_Verticality(Sprite sprite) //세로 모드
    {
        Bg_sp.sprite = sprite;

        Bg_sp.transform.localScale = new Vector2(
            sp.bounds.size.y / UnityEngine.Screen.height * UnityEngine.Screen.width / sp.bounds.size.x,
            Mathf.Ceil(Camera.main.orthographicSize * 2 / sp.bounds.size.y));
    }
    #endregion
}
