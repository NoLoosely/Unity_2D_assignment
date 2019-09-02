using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for changing scenes - attached on MainMenuManager object 
/// which exists in every scene ~ DontDestroyOnLoad()
/// </summary>
public class MainMenuController : MonoBehaviour
{
    private static MainMenuController _instance = null;
    public AudioSource buttonSound;

    public static MainMenuController Instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        if (_instance != null)
            return;
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLeve()
    {
        StartCoroutine(DelayForButtonSound(1));
    }

    public void BackToMainMenu()
    {
       StartCoroutine(DelayForButtonSound(0));
    }

    public void ExitGame()
    {
        StartCoroutine(DelayForExit());
    }

    IEnumerator DelayForButtonSound(int levelIndex)
    {
        buttonSound.Play();
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator DelayForExit()
    {
        buttonSound.Play();
        yield return new WaitForSecondsRealtime(0.2f);
        Application.Quit();
    }



} // class end
