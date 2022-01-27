using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text textScore;
    public AudioClip audioGameOver;

    public void SetUp(float score)
    {
        AudioSource.PlayClipAtPoint(audioGameOver, Camera.main.transform.position, 1f);
        gameObject.SetActive(true);
        textScore.text = score + " points ";
        transform.LeanMoveLocal(new Vector2(0, -10), 0.7f).setEaseInBack();
    }
}
