using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private GameObject renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUps"))
        {
            PowerUp_Base powerUp = other.GetComponentInParent<PowerUp_Base>();
            powerUp.Collect(this);
        }
    }

    public void UpdateScale(float scaleToAdd)
    {
        Vector3 actualScale = renderer.transform.localScale;
        actualScale = new Vector3(actualScale.x + scaleToAdd, actualScale.y + scaleToAdd, actualScale.z + scaleToAdd);
        renderer.transform.localScale = actualScale;

        SphereCollider coll = GetComponent<SphereCollider>();
        
        coll.radius += scaleToAdd;
        Vector3 center = coll.center;
        center = new Vector3(center.x, center.y + scaleToAdd, center.z);
        coll.center = center;
    }
    
    public void UpdateSpeed(float speedToAdd)
    {
        player.GetMovementController().SetSpeed(speedToAdd);
    }
    
    public void  UpdateJumpPower (float jumpToAdd)
    {
        player.GetMovementController().SetJumpPower(jumpToAdd);
    }
}
