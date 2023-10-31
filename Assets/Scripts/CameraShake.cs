using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    public void Shake()
    {
        initialPosition = cameraTransform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            Vector3 randomPoint = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, randomPoint, Time.deltaTime * dampingSpeed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraTransform.localPosition = initialPosition;
    }
}

