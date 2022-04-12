using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScale : PowerUp_Base
{
   public override void Collect(PowerUpCollector gameObjectToAffect)
   {
      gameObjectToAffect.UpdateScale(powerUpValue);
      base.Collect(gameObjectToAffect);
   }
}
