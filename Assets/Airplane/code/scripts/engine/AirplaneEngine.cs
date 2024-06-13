using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEngine : MonoBehaviour
{

    #region Variables
    public float maxPower = 10000f;
    public float maxRpm = 2550f;
    public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    public AirplanePropeller propeller;
    public float CurrentRPM { get; set; }
    #endregion

    #region CustomMethods
    public Vector3 CalculateForce(float throtle)
    {
        float finalThrottle = Mathf.Clamp01(throtle);
        finalThrottle = powerCurve.Evaluate(finalThrottle);

        CalculateRpm(finalThrottle);
        return CreateForce(finalThrottle);
    }

    private void CalculateRpm(float finalThrottle)
    {
        float currentRpm = finalThrottle * maxRpm;
        CurrentRPM = currentRpm;
        if (propeller)
            propeller.handlePropeller(currentRpm);
    }

    private Vector3 CreateForce(float finalThrottle)
    {
        float finalPower = finalThrottle * maxPower;
        return transform.forward * finalPower;
    }
    #endregion
}
