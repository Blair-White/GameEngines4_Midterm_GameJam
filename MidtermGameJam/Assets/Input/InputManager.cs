using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    private GameplayControls gameplayControls;
    public static InputManager Instance { get { return _instance; } }
    public GameObject UiMgr;
    

    private void Awake()
    {
     
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        gameplayControls = new GameplayControls();
        Cursor.visible = false;

        gameplayControls.MainGameplayControls.Pause.started += ctx => PausePushed();
        gameplayControls.MainGameplayControls.Pause.canceled += ctx => PauseReleased();
    }

    private void PausePushed()
    {
        
    }
    private void PauseReleased()
    {
        UiMgr = GameObject.Find("UiCanvas");//should not be doing this but issues+time. 
        UiMgr.SendMessage("PausePushed");
    }
    private void OnEnable()
    {
        gameplayControls.Enable();
    }

    public Vector2 GetPlayerMovement()
    {
        return gameplayControls.MainGameplayControls.Movement.ReadValue<Vector2>();        
    }

    public Vector2 GetMouseDelta()
    {
        return gameplayControls.MainGameplayControls.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return gameplayControls.MainGameplayControls.Jump.triggered;
    }

    public bool Interacted()
    {
        return gameplayControls.MainGameplayControls.Interact.triggered;
    }

    public bool EscapePushed()
    {
        return gameplayControls.MainGameplayControls.Pause.triggered;
    }

}
