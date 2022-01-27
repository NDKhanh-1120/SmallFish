using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public AudioClip audioWin;
    public  void DisplayYouWin()
    {
        gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(audioWin, Camera.main.transform.position, 1f);
        transform.LeanMoveLocal(new Vector2(0, -10), 1f).setEaseInBack();
    } 
}
