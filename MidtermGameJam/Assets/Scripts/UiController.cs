using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    private float timePassed;
    public GameObject TimeText, Score, PauseMenu;
    private int intScore, intTime;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        intTime = (int)timePassed;
        TimeText.GetComponent<TextMeshProUGUI>().text = intTime.ToString();
    }

    private void RoomCompleted()
    {
        intScore += 100 - intTime;
        Score.GetComponent<TextMeshProUGUI>().text = intScore.ToString();
        timePassed = 0; intTime = 0;
    }
    private void GameCompleted()
    {

    }

    public void PausePushed()
    {
        if (isPaused)
        {
            Cursor.visible = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            PauseMenu.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            isPaused = true;
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void GoToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
