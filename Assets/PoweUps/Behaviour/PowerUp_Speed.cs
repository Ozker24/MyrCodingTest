using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp_Base
{
    public override void Collect(PowerUpCollector gameObjectToAffect)
    {
        gameObjectToAffect.UpdateSpeed(powerUpValue);
        base.Collect(gameObjectToAffect);
    }
}
