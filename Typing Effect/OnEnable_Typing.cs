using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnEnable_Typing : MonoBehaviour
{
    [Header("타이핑할 텍스트")]
    public string txt;
    [Header("타이핑 간격")]
    public float delay;

    //타이핑할 TMP 개체
    TextMeshProUGUI textMeshProUGUI;


 // #1 실행단계
    private void OnEnable()
    {
        /*
         * 타 스크립트에서 호출할 때 SetActive를 통해 해당 개체를 활성화시켜 실행합니다.
         * 
         * 첫 수행에 TMP를 할당하고 값을 초기화합니다.
         * 타이핑 이펙트는 Coroutine을 통해 수행합니다.
         */

        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = "";

        StartCoroutine(Typing());
    }

//  #2 값의 변경
    IEnumerator Typing()
    {
        /*
         * TMP에 char형인 txt[index]를 +=해서 한 글자씩 추가되는 애니메이션을 진행합니다.
         * yield return new WaitForSeconds(delay)로 각 간격의 딜레이를 조절합니다.
         * 
         * 모든 txt를 더한 후 Stay_Event로 이동합니다.
         */

        for (int i = 0; i < txt.Length; i++)
        {
            textMeshProUGUI.text += txt[i];
            yield return new WaitForSeconds(delay);
        }

        StartCoroutine(Stay_Event());
    }

//  #3 처리 이후
    IEnumerator Stay_Event()
    {
        /*
         * 모든 txt가 입력된 후 플레이어의 응답을 대기할 때 사용하는 함수입니다.
         * 
         * 0.5초의 딜레이마나 점(.)을 추가하고 3개 이후로는 다시 초기화하여 루프합니다.
         */

        string temp = textMeshProUGUI.text;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < 3; i++)
            {
                textMeshProUGUI.text += ".";
                yield return new WaitForSeconds(0.5f);
            }
            textMeshProUGUI.text = temp;
        }
    }
}
