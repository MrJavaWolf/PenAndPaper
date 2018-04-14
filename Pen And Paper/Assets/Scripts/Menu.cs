using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	private XBoxInput inputA;

	public void GoToScene (string name) {
		SceneManager.LoadScene(name);
	}

	public void Start() {
		inputA = InputController.Instance.GetXBoxInput();
	}

	public void Update() {
       if(inputA.ButtonX || inputA.ButtonA || inputA.ButtonB || inputA.ButtonY) {
		   GoToScene("Character Select");
	   }
	}
}
