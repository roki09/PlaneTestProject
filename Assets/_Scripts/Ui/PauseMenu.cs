using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private void OnEnable()
    {
        PauseOn();
    }

    private void OnDisable()
    {
        PauseOff();
    }

    private void PauseOn()
    {
        Time.timeScale = 0f;
    }

    private void PauseOff()
    {
        Time .timeScale = 1f;
    }
}
