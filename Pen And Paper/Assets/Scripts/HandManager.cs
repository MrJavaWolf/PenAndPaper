using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public MeshRenderer PaperHand1;
    public MeshRenderer PaperHand2;
    public MeshRenderer PencilHand;
    public Material ManMaterial;
    public Material WomanMaterial;

    void Start()
    {
        if (CharacterManager.Instance.characterPlayerA == 0)
        {
            PencilHand.material = ManMaterial;
        }
        else
        {
            PencilHand.material = WomanMaterial;
        }

        if (CharacterManager.Instance.characterPlayerB == 0)
        {
            PaperHand1.material = ManMaterial;
            PaperHand2.material = ManMaterial;
        }
        else
        {
            PaperHand1.material = WomanMaterial;
            PaperHand2.material = WomanMaterial;
        }
    }
}
