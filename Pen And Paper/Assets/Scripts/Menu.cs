using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneName;

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Update()
    {
        if (InputManager.ActiveDevice.AnyButton)
        {
            GoToScene(sceneName);
        }
    }
}