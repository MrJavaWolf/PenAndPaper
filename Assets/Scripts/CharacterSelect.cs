using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int currentSelection = 0;
    private bool confirmed = false; // Player selected a character

    public bool firstPlayer = true;

    private Vector2 userInputMovement;

    private ReadyCheck readyCheck;

    private GameObject avatarsA;
    private GameObject avatarsB;

    // Use this for initialization
    void Start()
    {
        avatarsA = GameObject.Find("Character Avatars 1");
        avatarsB = GameObject.Find("Character Avatars 2");

        userInputMovement = Vector2.zero;

        readyCheck = GameObject.Find("Ready Check").GetComponent<ReadyCheck>();

        this.Left();
    }

    void HideAllAvatars(string characterRole)
    {
        GameObject avatars;

        if (characterRole == "A")
        {
            avatars = avatarsA;
        }
        else
        {
            avatars = avatarsB;
        }

        foreach (Transform child in avatars.transform)
        {
            SpriteRenderer sprite = child.gameObject.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }
    }

    void Left()
    {
        this.MoveCursor(1);
    }

    void Right()
    {
        this.MoveCursor(-1);
    }
    void Down()
    {
        this.MoveCursor(3);
    }
    void Up()
    {
        this.MoveCursor(-3);
    }

    void MoveCursor(int amount)
    {
        this.updateSelected(this.currentSelection, false);
        this.currentSelection = this.currentSelection + amount;
        if (this.currentSelection < 0)
        {
            this.currentSelection += 6;
        }
        this.currentSelection = (this.currentSelection % 6);
        this.updateSelected(this.currentSelection, true);
    }

    void updateSelected(int newSelection, bool isOn)
    {
        string boxNo = (newSelection + 1).ToString();
        GameObject box = transform.Find("Character " + boxNo).gameObject;
        CharacterBox characterBox = box.GetComponent<CharacterBox>();

        if (isOn)
        {
            Transform audioHoverObject = box.transform.Find("Hovered Audio");
            if (audioHoverObject)
            {
                audioHoverObject.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        characterBox.Toggle(isOn);
        UpdateSelectedAvatar();
    }

    void UpdateSelectedAvatar()
    {
        string characterName = "Unknown";
        switch (this.currentSelection)
        {
            case 0:
                characterName = "Brute";
                break;
            case 1:
                characterName = "Feme";
                break;
            default:
                characterName = "Unlock" + (this.currentSelection - 1).ToString();
                break;
        }

        this.HideAllAvatars(this.CharacterRole());

        GameObject avatars;

        if (this.CharacterRole() == "A")
        {
            avatars = this.avatarsA;
        }
        else
        {
            avatars = this.avatarsB;
        }

        SpriteRenderer sprite = avatars.transform.Find(characterName).GetComponent<SpriteRenderer>();
        sprite.enabled = true;
    }

    string CharacterRole()
    {
        if (this.firstPlayer)
        {
            return "A";
        }
        else
        {
            return "B";
        }
    }

    // Update is called once per frame
    void Update()
    {
        float slowdown = 0.9f;
        float treshold = 3.5f;

        if (!confirmed)
        {
            if (firstPlayer)
            {
                if (InputManager.Devices[0].AnyButton)
                {
                    if (this.currentSelection == 0 || this.currentSelection == 1)
                    {
                        string boxNo = (this.currentSelection + 1).ToString();
                        GameObject box = transform.Find("Character " + boxNo).gameObject;
                        Transform audioSelectObject = box.transform.Find("Selected Audio");
                        if (audioSelectObject)
                        {
                            audioSelectObject.gameObject.GetComponent<AudioSource>().Play();
                        }

                        this.confirmed = true;
                        readyCheck.SetReady("A", true);
                        GameObject.Find("Character Manager").GetComponent<CharacterManager>().characterPlayerA = this.currentSelection;
                    }
                }

                this.userInputMovement += InputManager.Devices[0].LeftStick;
            }
            else
            {
                if (InputManager.Devices[1].AnyButton)
                {
                    if (this.currentSelection == 0 || this.currentSelection == 1)
                    {
                        string boxNo = (this.currentSelection + 1).ToString();
                        GameObject box = transform.Find("Character " + boxNo).gameObject;
                        Transform audioSelectObject = box.transform.Find("Selected Audio");
                        if (audioSelectObject)
                        {
                            audioSelectObject.gameObject.GetComponent<AudioSource>().Play();
                        }

                        this.confirmed = true;
                        readyCheck.SetReady("B", true);
                        GameObject.Find("Character Manager").GetComponent<CharacterManager>().characterPlayerB = this.currentSelection;
                    }
                }

                this.userInputMovement += InputManager.Devices[1].LeftStick;
            }

            this.userInputMovement *= slowdown;

            if (this.userInputMovement.x > treshold)
            {
                this.Right();
                this.userInputMovement = Vector2.zero;
            }

            if (this.userInputMovement.x < treshold * -1f)
            {
                this.Left();
                this.userInputMovement = Vector2.zero;
            }

            if (this.userInputMovement.y > treshold)
            {
                this.Up();
                this.userInputMovement = Vector2.zero;
            }

            if (this.userInputMovement.y < treshold * -1f)
            {
                this.Down();
                this.userInputMovement = Vector2.zero;
            }
        }
    }
}