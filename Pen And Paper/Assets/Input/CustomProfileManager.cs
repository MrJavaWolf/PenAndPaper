using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomProfileManager : Singleton<CustomProfileManager>
{

	// Use this for initialization
	void Start()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;

		if (InputManager.Devices.Count == 0)
		{
			InputManager.AttachDevice(new UnityInputDevice(new PlayerTwoProfile()));
			InputManager.AttachDevice(new UnityInputDevice(new PlayerOneProfile()));
		}
		else if (InputManager.Devices.Count == 1)
		{
			InputManager.AttachDevice(new UnityInputDevice(new PlayerOneProfile()));
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Play")
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}

	// Update is called once per frame
	void Update() { }

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}