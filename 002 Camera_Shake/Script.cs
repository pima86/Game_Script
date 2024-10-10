using System.Collections;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    #region 싱글톤
    public static Camera_Shake Inst;
    private void Awake() => Inst = this;
    #endregion

    public Transform cam;

    public float shakeTime;
    public float shakeSpeed;
    public float shakeAmount;
   
    public IEnumerator Shake()
    {
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            randomPoint = new Vector3(randomPoint.x, randomPoint.y, originPosition.z);
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        cam.localPosition = originPosition;
    }
}
