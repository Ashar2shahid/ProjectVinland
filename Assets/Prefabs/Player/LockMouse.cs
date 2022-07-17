using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockMouse : MonoBehaviour
{
    //Globals
    public static LockMouse Instance { get; private set; }
    public bool IsLocked { get; private set; } = true;
    private FirstPersonController ownController;


    //Events
    public event Action<bool> OnLockChange;


    //Functions
    private void Start()
    {
        Instance = this;

        ownController = GetComponent<FirstPersonController>();
        SetCursorLockState(true);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SetCursorLockState(false);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            SetCursorLockState(true);
        }
    }


    private void SetCursorLockState(bool isLocked)
    {
        IsLocked = isLocked;
        ownController.cameraCanMove = isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        OnLockChange?.Invoke(isLocked);
    }
}
