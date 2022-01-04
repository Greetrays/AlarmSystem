using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void SwitchGame(float isGame)
    {
        Time.timeScale = isGame;
    }
}
