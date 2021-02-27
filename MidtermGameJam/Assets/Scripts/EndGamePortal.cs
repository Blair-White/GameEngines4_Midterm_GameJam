using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePortal : MonoBehaviour
{
    public GameObject WinMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Entered()
    {
        WinMenu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
