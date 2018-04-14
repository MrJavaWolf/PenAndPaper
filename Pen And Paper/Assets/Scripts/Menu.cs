using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private XBoxInput inputA;
    private Ps4Input inputB;

    public string sceneName;

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Start()
    {
        inputA = InputController.Instance.GetXBoxInput();
        inputB = InputController.Instance.GetPs4Input();
    }

    public void Update()
    {
        if (inputA.ButtonX || inputA.ButtonA || inputA.ButtonB || inputA.ButtonY ||
             inputB.ButtonCircle || inputB.ButtonSquare || inputB.ButtonTriangle || inputB.ButtonX)
        {
            GoToScene(sceneName);
        }
    }
}
