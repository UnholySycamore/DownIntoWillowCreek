using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string actualDialogue;
    public int speakerNum;

    public Dialogue(string dialogue, int speakerNumber)
    {
        actualDialogue = dialogue;
        speakerNum = speakerNumber;
    }
}
