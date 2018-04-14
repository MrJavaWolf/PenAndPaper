using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBox : MonoBehaviour {
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
      this.initialPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Toggle (bool isOn) {
		if(isOn == true) {
			transform.position = this.initialPosition - new Vector3(0, 0, 0.75f);
		} else {
			transform.position = this.initialPosition;
		}

	}
}
