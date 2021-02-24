using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public static CameraEffect Instance;

    void Awake()
    {
        Instance = this;
    }

    bool isShaking = false;
    public void ShakeCam(float duration, float magnitude)
    {
        if (!isShaking)
            StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        isShaking = true;
        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.position;
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }

        transform.position = originalCamPos;
        isShaking = false;
    }
}
