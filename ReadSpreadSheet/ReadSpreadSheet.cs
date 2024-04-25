using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ReadSpreadSheet : MonoBehaviour
{
    public static ReadSpreadSheet Inst;
    private void Awake() => Inst = this;

    //불러오기 좋게 주소값을 수정해줌
    public static string GetTSVAddress(string address, string range, long sheetID)
    {
        return $"{address}/export?format=tsv&range={range}&gid={sheetID}";
    }

    //해당 주소값으로 엑셀내 데이터를 불어오는 역할
    public IEnumerator LoadData(string ADDRESS, string RANGE, long SHEET_ID)
    {
        UnityWebRequest www = UnityWebRequest.Get(GetTSVAddress(ADDRESS, RANGE, SHEET_ID));
        yield return www.SendWebRequest();

        string[] data = www.downloadHandler.text.Split("\n");

        Digimon_Data_Spread.Inst.SetUp_Digimon_Data(data);

        Debug.Log("스프레드시트에서 데이터를 가져왔습니다.");
    }
}
