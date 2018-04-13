using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
	public int currentSelection = 1;

	// Use this for initialization
	void Start () {
		
	}

	void Left() {
      
	}

	void updateSelected (int newSelection, bool isOn) {
      GameObject box = transform.Find("Character " + newSelection.ToString()).gameObject;
	  CharacterBox characterBox = box.GetComponent<CharacterBox>();
	  characterBox.Toggle(isOn);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.RightArrow)) {
			this.updateSelected(this.currentSelection, false);
			this.currentSelection = (this.currentSelection) % 6 + 1;
			this.updateSelected(this.currentSelection, true);
		}
	}
}
