using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject wristUI;
    [SerializeField] private bool activeWristUI = true;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject pause;

    private void Start()
    {
        DisplayWristUI();
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayWristUI();
            pause.SetActive(true);
        }
    }

    public void DisplayWristUI()
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        wristUI.SetActive(false);
        activeWristUI = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Inventory()
    {
        pause.SetActive(false);
        inventory.SetActive(true);
        Time.timeScale = 1;
    }

    public void InventoryReturn()
    {
        inventory.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 0;
    }
}
