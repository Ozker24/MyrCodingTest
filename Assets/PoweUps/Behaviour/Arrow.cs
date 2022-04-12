using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Start()
    {
        PowerUp_Base powerUp = GetComponentInParent<PowerUp_Base>();

        Quaternion originalRotation = gameObject.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(originalRotation.x, originalRotation.y, 0);
        if (powerUp.GetPowerUpValue() <= 0) gameObject.transform.rotation = newRotation;
    }
}
