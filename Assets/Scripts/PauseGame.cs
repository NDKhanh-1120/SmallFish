using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Display(bool status)
    {
        if (status)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
