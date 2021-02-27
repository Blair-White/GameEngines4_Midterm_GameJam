using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPushed()
    {
        SceneManager.LoadScene(1);
    }
    public void CreditsPushed()
    {
        SceneManager.LoadScene(2);
    }

    public void EndCredits()
    {
        SceneManager.LoadScene(0);
    }
}
