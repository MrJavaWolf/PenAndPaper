using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        PaperController.Instance.OnPaperRip += Instance_OnPaperRip;
        ShapeManager.Instance.PaperPunctured += Instance_PaperPunctured;
        ShapeManager.Instance.GameEnded += Instance_GameEnded;
    }

    private void Instance_GameEnded()
    {
        SceneManager.LoadScene("Finished Won");
    }

    private void Instance_PaperPunctured()
    {
        SceneManager.LoadScene("Finished Lost");
    }

    private void Instance_OnPaperRip(object sender, System.EventArgs e)
    {
        SceneManager.LoadScene("Finished Lost");

    }
}
