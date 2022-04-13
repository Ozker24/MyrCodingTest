using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private GameObject renderer;
    [Header("Power Up Caps")] 
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [Space]
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;
    [Space]
    [SerializeField] private float minJumpPower;
    [SerializeField] private float maxJumpPower;

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

        if (CheckCaps(scaleToAdd, minScale, maxScale, actualScale.x))
        {
            if (actualScale.x + scaleToAdd < minScale) renderer.transform.localScale = new Vector3(minScale,minScale,minScale);
            else if (actualScale.x + scaleToAdd > maxScale) renderer.transform.localScale = new Vector3(maxScale,maxScale,maxScale);

            gameObject.transform.localScale = renderer.transform.localScale;
            
            return;
        }
        
        Vector3 finalScale = new Vector3(actualScale.x + scaleToAdd, actualScale.y + scaleToAdd, actualScale.z + scaleToAdd);
        renderer.transform.localScale = finalScale;
        
        gameObject.transform.localScale = renderer.transform.localScale;
    }
    public void UpdateSpeed(float speedToAdd)
    {
        float actualSpeed = player.GetMovementController().GetSpeed();
        
        if (CheckCaps(speedToAdd, minSpeed, maxSpeed, actualSpeed))
        {
            if(actualSpeed + speedToAdd < minSpeed) player.GetMovementController().SetSpeed(minSpeed);
            else if(actualSpeed + speedToAdd > minSpeed) player.GetMovementController().SetSpeed(maxSpeed);
        }
        else player.GetMovementController().AddSpeed(speedToAdd);
    }
    public void UpdateJumpPower (float jumpToAdd)
    {
        float actualJumpPower = player.GetMovementController().GetJumpPower();
        
        if (CheckCaps(jumpToAdd, minJumpPower, maxJumpPower, actualJumpPower))
        {
            if(actualJumpPower + jumpToAdd < minJumpPower) player.GetMovementController().SetJumpPower(minJumpPower);
            else if(actualJumpPower + jumpToAdd > maxJumpPower) player.GetMovementController().SetJumpPower(maxJumpPower);
        }
        else player.GetMovementController().AddJumpPower(jumpToAdd);
    }
    private bool CheckCaps(float valueToAdd, float minValue, float maxValue, float actualValue)
    {
        float finalValue = actualValue + valueToAdd;
        bool crossedACap = finalValue < minValue || finalValue > maxValue;

        return crossedACap;
    }
}
