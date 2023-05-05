using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGameManager : MonoBehaviour
{
    public GameObject  loading;

    private void Start()
    {
        loading.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Loading()
    {
        loading.SetActive(true);
    }

    public void Chapter_01()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
