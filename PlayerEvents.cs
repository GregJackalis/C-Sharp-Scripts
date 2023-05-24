using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class PlayerEvents : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameOverUIScreen;
    public GameObject gameWonUI;
    public GameObject gamePauseUI;
    public GameObject Camera;

    public int nextlevel;

    [SerializeField] private List<Scene> _sceneList;
    public static bool isPaused;

    private void Update()
    {
        if (HVRInputManager.Instance.LeftController.SecondaryButtonState.JustActivated)
        {
            isPaused = !isPaused;
            PauseGame();
        }
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Destroy(gamePauseUI);
    }

    public void GameWon()
    {
        gameWonUI.SetActive(true);
        Destroy(gamePauseUI);
        Destroy(gameOverUIScreen);
        PlayerPrefs.SetInt("levelreached", nextlevel);
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex));
    }

    public void MainMenu(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(0));
    }

    public GameObject loadingScreen;
    public Image loadingBarFill;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            gamePauseUI.SetActive(true);
        }
        else
        {
            gamePauseUI.SetActive(false);
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void PlayerPrefsDelete()
    {
        PlayerPrefs.DeleteAll();
    }
}


