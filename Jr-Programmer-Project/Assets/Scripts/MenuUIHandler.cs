using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.instance.TeamColor = color;
    }


    private void Start()
    {
        if (ColorPicker != null)
        {
            ColorPicker.Init();
            //this will call the NewColorSelected function when the color picker have a color button clicked.
            ColorPicker.onColorChanged += NewColorSelected;
            ColorPicker.SelectColor(MainManager.instance.TeamColor);

        }

    }
    public void StartNew()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        MainManager.instance.SaveColor();
        EditorApplication.ExitPlaymode();
#else
        MainManager.instance.SaveColor(); 
        Application.Quit();
#endif
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void SaveColorClicked()
    {
        MainManager.instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.instance.LoadColor();
        ColorPicker.SelectColor(MainManager.instance.TeamColor);
    }

}
