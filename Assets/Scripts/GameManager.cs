using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public GameObject finishScreen;

    public bool isPlaying;
    public bool hasFinished;
    public float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timePassed += Time.deltaTime;
            timerText.text = (Mathf.Round(timePassed * 100f) / 100f).ToString();
        }
    }
    void StartGame()
    {
        isPlaying = true;
    }

    public void FinishLevel()
    {
        hasFinished = true;
        isPlaying = false;
        Invoke("ShowEndMenu", 2f);
        
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    void ShowEndMenu()
    {

        finishScreen.SetActive(true);
    }
}
