using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public static void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    //public static void LoadGameOver()
    //{
    //    SceneManager.LoadScene("GameOver");
    //}
    public static void LoadListLevels()
    {
        SceneManager.LoadScene("ListLevels");
    }
    public static void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level "+ levelIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
