using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUp_Jump : PowerUp_Base
{
    public override void Collect(PowerUpCollector gameObjectToAffect)
    {
        gameObjectToAffect.UpdateJumpPower(powerUpValue);
        base.Collect(gameObjectToAffect);
    }
}
