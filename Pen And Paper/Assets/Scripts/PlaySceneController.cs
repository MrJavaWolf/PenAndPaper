using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneController : Singleton<PlaySceneController>
{
    // Use this for initialization
    void Start()
    {
        PaperController.Instance.OnPaperRip += Instance_OnPaperRip;
        ShapeManager.Instance.OnPenBreaking += Instance_OnPenBreaking;
        ShapeManager.Instance.GameEnded += Instance_GameEnded;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Instance_OnPenBreaking();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Instance_OnPaperRip(this, EventArgs.Empty);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Instance_GameEnded();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ShapeManager.Instance.GoToNextShape();
        }
        
    }

    private void Instance_GameEnded()
    {
        SceneManager.LoadScene("Finished Won");
    }

    private void Instance_OnPenBreaking()
    {
        DisablePlayScripts();
        PencilBrokeScript.Instance.Play(() =>
        {
            SceneManager.LoadScene("Finished Lost");
        });
    }

    private void Instance_OnPaperRip(object sender, System.EventArgs e)
    {
        DisablePlayScripts();
        PaperRipScript.Instance.Play(() =>
        {
            SceneManager.LoadScene("Finished Lost");
        });
    }


    public void DisablePlayScripts()
    {
        var cameraPoints = FindObjectsOfType<CameraPoint>();
        foreach (var camPoint in cameraPoints)
        {
            camPoint.enabled = false;
        }
        PenController.Instance.enabled = false;
        PaperController.Instance.enabled = false;
        ShapeManager.Instance.enabled = false;
        var shapeControllers = FindObjectsOfType<ShapeController>();
        foreach (var shapeController in shapeControllers)
        {
            shapeController.enabled = false;
        }
    }

    public void EnablePlayScripts()
    {
        var cameraPoints = FindObjectsOfType<CameraPoint>();
        foreach (var camPoint in cameraPoints)
        {
            camPoint.enabled = true;
        }
        PenController.Instance.enabled = true;
        PaperController.Instance.enabled = true;
        ShapeManager.Instance.enabled = true;
        var shapeControllers = FindObjectsOfType<ShapeController>();
        foreach (var shapeController in shapeControllers)
        {
            shapeController.enabled = true;
        }
    }
}
