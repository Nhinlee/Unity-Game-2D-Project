using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionPulse : MonoBehaviour
{
    [SerializeField] float _maxIntensity = 1f;       // Max intensity of color to be render
    [SerializeField] float _damping = 0.2f;             // Damping

    Material _myMaterial;           // Cache material to control emission
    int _emissionPropertyID;        // Hash ID of emission property

    // Start is called before the first frame update
    void Start()
    {
        // Get material of this object
        _myMaterial = GetComponent<Renderer>().material;
        // Get Hash ID of emission property
        _emissionPropertyID = Shader.PropertyToID("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        // Ping Pong Color between min and max intensity
        float intensity = Mathf.PingPong(Time.time * _damping, _maxIntensity);
        // Final color
        Color finalColor = Color.white * intensity;

        // Set color to emission property
        _myMaterial.SetColor(_emissionPropertyID, finalColor);

    }
}
