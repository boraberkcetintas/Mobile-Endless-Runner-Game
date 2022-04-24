using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour
{
    #region
    private static camControl instance;
    public static camControl GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion


    public Transform target;
    private Vector3 desiredPos;
    public Vector3 offset;

    [Range(0.0f, 1.0f)] public float smoothSpeed;
    [Range(0.0f, 5.0f)] public float lookSmooth;
    [Range(-1.0f, 5.0f)] public float targetDiffy;
    [Range(-1.0f, 5.0f)] public float targetDiffz;


    private void FixedUpdate()
    {
        desiredPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

        lookPoint(target, new Vector3(0, 0, 1) * targetDiffz + new Vector3(0, 1, 0) * targetDiffy, lookSmooth);
    }

    private void lookPoint(Transform target, Vector3 offset, float smooth)
    {
        Quaternion targetDirection = Quaternion.LookRotation(target.position + offset - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetDirection, smooth * Time.deltaTime);
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeIE(duration, magnitude));
    }
    public IEnumerator ShakeIE(float duration, float magnitude)
    {
        yield return new WaitForSeconds(0.2f);

        Vector3 orginalPos = transform.GetChild(0).localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.GetChild(0).localPosition = new Vector3(x, y, orginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.GetChild(0).localPosition = orginalPos;
    }


}
