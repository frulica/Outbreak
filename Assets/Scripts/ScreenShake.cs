using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower, shakeRotation;

    public float defaultShakeLength, defaultShakePower, shakeFadeTime, rotationMultiplyer;

    private Vector3 position;
    private Quaternion rotation;

    private void Awake()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining >0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            transform.position = position;
            transform.rotation = rotation;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0, shakeFadeTime * rotationMultiplyer * Time.deltaTime);
        }
        else
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }

    public void StartShake()
    {
        shakeTimeRemaining = defaultShakeLength;
        shakePower = defaultShakePower;

        shakeFadeTime = shakePower / defaultShakeLength;
        shakeRotation = defaultShakePower * rotationMultiplyer;
    }
}
