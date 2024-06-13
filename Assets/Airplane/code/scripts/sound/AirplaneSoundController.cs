using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource airplaneSound;
    [SerializeField]
    private AirplaneEngine airplaneEngine;

    void Start()
    {
        airplaneSound = GetComponent<AudioSource>();
        airplaneEngine = GetComponent<AirplaneEngine>();
    }

    void Update()
    {
        HandleAudio();
    }

    private void HandleAudio()
    {
        if (airplaneEngine.CurrentRPM > 0)
        {
            airplaneSound.Play();
            airplaneSound.pitch = airplaneEngine.CurrentRPM * .0001f; 
            Debug.Log($"RPM = {airplaneEngine.CurrentRPM}");
        }
        else
        {
            airplaneSound.Stop();
        }
    }
}
