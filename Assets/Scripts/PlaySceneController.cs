﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneController : Singleton<PlaySceneController>
{
    public InAudioEvent StopAudio;
    public static bool SoundPlay;

    // Use this for initialization
    void Start()
    {
        SoundPlay = true;

        PaperController.Instance.OnPaperRip += Instance_OnPaperRip;
        ShapeManager.Instance.OnPenBreaking += Instance_OnPenBreaking;
        ShapeManager.Instance.GameEnded += Instance_GameEnded;
    }

    private void Instance_GameEnded()
    {
        SceneManager.LoadScene("Finished Won");
    }

    private void Instance_OnPenBreaking()
    {
        DisablePlayScripts();
        InAudio.PostEvent(gameObject, StopAudio);
        SoundPlay = false;
        PencilBrokeScript.Instance.Play(() =>
        {
            SceneManager.LoadScene("Finished Lost");
        });
    }

    private void Instance_OnPaperRip(object sender, System.EventArgs e)
    {
        InAudio.PostEvent(gameObject, StopAudio);
        DisablePlayScripts();
        SoundPlay = false;
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