using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //VARIABLES
    private GameObject menu;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    private GameObject settingsMenu;

    void Start()
    {
        menu = GameObject.Find("Menu");
        menu.SetActive(false);
        settingsMenu = GameObject.Find("SettingsMenu");
        settingsMenu.SetActive(false);
        GetResolutions();
    }

    public void hideMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;  
    }

    public void QuitGame()
    {
        Debug.Log("ExitingGame");
        Application.Quit();
    }

    public void GetResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string>options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0;i <resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width==Screen.currentResolution.width && resolutions[i].height== Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        menu.SetActive(true);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
           menu.SetActive(true);
           Cursor.lockState = CursorLockMode.None;

        }
    }
}
