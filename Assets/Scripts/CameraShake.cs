using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   [SerializeField] float shakeDuration = 1f;
   [SerializeField] float shakeMagnitude = 0.01f;

   Vector3 originalPosition;

   void Start() {
    
   }

   public void ShakeCamera() {
       originalPosition = transform.localPosition;
       StartCoroutine(ShakeCoroutine());
   }

    IEnumerator ShakeCoroutine()
    {
        for (float elapsed = 0; elapsed < shakeDuration; elapsed += Time.deltaTime)
        {
            transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return null;
        }
        transform.localPosition = originalPosition;

    }
}
