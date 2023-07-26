using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public GameObject[] speakers;
    public GameObject textBubble;

    public Vector3 bubbleOffset = new Vector3();

    private List<Dialogue> textQueue = new List<Dialogue>();

    private int currentQueueSpot;
    private bool isTextFinished = false;
    private bool isQueue = false;
    private GameObject currentText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isQueue)
        {
            if (isTextFinished) PlayNextInQueue();
            else FinishQueue();
        }
    }

    private void FinishQueue()
    {
        isTextFinished = true;
    }

    private void PlayNextInQueue()
    {
        isTextFinished = false;

        //passes the first text bubble even thoug there is no value for currentText
        try { Destroy(currentText); } catch { }

        bool textPassed = false;

        try
        {
            int x = textQueue[currentQueueSpot].speakerNum;
            textPassed = true;
        }
        catch
        {
            textPassed = false;
            ResetQueue();
        }

        if (textPassed)
        {
            currentText = Instantiate(textBubble, speakers[textQueue[currentQueueSpot].speakerNum].transform.position + bubbleOffset, Quaternion.Euler(0, 0, 0));
            currentText.GetComponentInChildren<TextMeshProUGUI>().text = textQueue[currentQueueSpot].actualDialogue;
            currentQueueSpot++;

            isTextFinished = true;
        }
    }

    public void StartQueue()
    {
        isQueue = true;
    }

    public void AddToQueue(Dialogue dialogue)
    {
        textQueue.Add(dialogue);
    }

    public void AddToQueue(Dialogue[] dialogues)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            textQueue.Add(dialogue);
        }
    }

    private void ResetQueue()
    {
        isQueue = false;
        currentQueueSpot = 0;
        textQueue = new List<Dialogue>();
}
}
