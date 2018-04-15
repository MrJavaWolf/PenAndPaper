using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenCharacters : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject characterManager = GameObject.Find("Character Manager");
		int characterA = characterManager.GetComponent<CharacterManager>().characterPlayerA;
		int characterB = characterManager.GetComponent<CharacterManager>().characterPlayerB;

		GameObject charactersPlayerA = GameObject.Find("CharactersPlayerA");
		GameObject charactersPlayerB = GameObject.Find("CharactersPlayerB");

		if(characterA == 0) {
			charactersPlayerA.transform.Find("Brute").GetComponent<SpriteRenderer>().enabled = true;
		} else {
			charactersPlayerA.transform.Find("Feme").GetComponent<SpriteRenderer>().enabled = true;
		}

		if(characterB == 0) {
			charactersPlayerB.transform.Find("Brute").GetComponent<SpriteRenderer>().enabled = true;
		} else {
			charactersPlayerB.transform.Find("Feme").GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
