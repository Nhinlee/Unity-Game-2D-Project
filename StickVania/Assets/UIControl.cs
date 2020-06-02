using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Tag Toggle
    bool _pauseToggle = false;
    [SerializeField] Canvas _menu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseToggle)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;

            _pauseToggle = !_pauseToggle;
        }

        _menu.enabled = _pauseToggle? true : false;
    }
}
