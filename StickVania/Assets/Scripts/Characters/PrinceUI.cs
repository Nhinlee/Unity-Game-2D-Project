using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrinceUI : MonoBehaviour
{
    // Reference to nessesary object to control UI
    [SerializeField] Slider _princeHealth;
    [SerializeField] TextMeshProUGUI _keyStones;
    Prince _prince;
    // Start is called before the first frame update
    void Start()
    {
        // Get prince object
        _prince = FindObjectOfType<Prince>();
        _princeHealth.maxValue = _prince.Health;
        _princeHealth.minValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Health runtime
        _princeHealth.value = _prince.Health;
        // Update KeyStone number runtime
        _keyStones.text = _prince.KeyStones.ToString();
    }
}
