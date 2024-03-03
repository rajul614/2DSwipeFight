
using System;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    #region Events
    public delegate void Move();
    public event Move OnMoveUpdated;

    #endregion
    PlayerInputActions playerInput;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInputActions();
        
    }

    private void onEnable()
    {
        playerInput.Enable();
    }

    private void onDisable()
    {
        playerInput.Disable();
    }

    void Start()
    {
        playerInput.PlayerControls.PrimaryContact.started += ctx => TouchStarted(ctx);
        playerInput.PlayerControls.PrimaryContact.canceled += ctx => TouchEnded(ctx);
        
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        
    }
    
    private void TouchEnded(InputAction.CallbackContext context)
    {
        
    }
}
