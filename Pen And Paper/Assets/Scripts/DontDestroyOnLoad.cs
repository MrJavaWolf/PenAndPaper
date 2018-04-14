using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public bool DontDestroyOnLoadConfig;

    [Header("Audio Events")]
    public InAudioEvent EnterMain;
    public InAudioEvent EnterSelect;
    public InAudioEvent EnterGame;
    public InAudioEvent EnterLose;
    public InAudioEvent EnterWin;

    private void Start()
    {
        InAudio.PostEvent(gameObject, EnterMain);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(arg0.name);

        switch (arg0.name)
        {
            case "Play":
                InAudio.PostEvent(gameObject, EnterMain);
                break;

            case "Start":
                InAudio.PostEvent(gameObject, EnterGame);
                break;

            case "Finished Lost":
                InAudio.PostEvent(gameObject, EnterLose);
                break;

            case "Finished Won":
                InAudio.PostEvent(gameObject, EnterWin);
                break;

            case "Character Select":
                InAudio.PostEvent(gameObject, EnterSelect);
                break;
        }

    }

    [ExecuteInEditMode]
    protected virtual void Awake()
    {
        if (DontDestroyOnLoadConfig)
            DontDestroyOnLoad(gameObject);
    }


}
