using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Base : MonoBehaviour
{
    [SerializeField] protected float powerUpValue;
    public virtual void Collect(PowerUpCollector gameObjectToAffect)
    {
        Destroy(gameObject);
    }

    public float GetPowerUpValue()
    {
        return powerUpValue;
    }
}
