using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
	public int currentSelection = 0;
	private bool confirmed = false; // Player selected a character

	// Use this for initialization
	void Start () {
	  //this.MoveCursor(0);
	}

	void Left() {
		this.MoveCursor(1);
	}

	void Right() {
		this.MoveCursor(-1);
	}
	void Down() {
		this.MoveCursor(3);
	}
	void Up() {
		this.MoveCursor(-3);
	}

	void MoveCursor(int amount) {
		this.updateSelected(this.currentSelection, false);
		this.currentSelection = this.currentSelection + amount;
		if(this.currentSelection < 0) {
			this.currentSelection += 6;
		}
		this.currentSelection = (this.currentSelection % 6);
		Debug.Log(this.currentSelection);
		this.updateSelected(this.currentSelection, true);
	}

	void updateSelected (int newSelection, bool isOn) {
		string boxNo = (newSelection + 1).ToString();
      	GameObject box = transform.Find("Character " + boxNo).gameObject;
	    CharacterBox characterBox = box.GetComponent<CharacterBox>();
	    characterBox.Toggle(isOn);
	}
	
	// Update is called once per frame
	void Update () {
		if(!confirmed) {
			if(Input.GetKeyUp(KeyCode.RightArrow)) {
				this.Right();
			}

			if(Input.GetKeyUp(KeyCode.LeftArrow)) {
				this.Left();
			}

			if(Input.GetKeyUp(KeyCode.UpArrow)) {
				this.Up();
			}

			if(Input.GetKeyUp(KeyCode.DownArrow)) {
				this.Down();
			}
		}
	}
}
