using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public TextManager tm;

    private Dialogue[] testConversation =
    {
        new Dialogue("Hi there! Who are you guys?", 0),
        new Dialogue("Shut up new kid! Don't you recognize the fleeting nature of our reality-", 1),
        new Dialogue("What?", 0),
        new Dialogue("They don't see it. The way our world is just an abstraction of something more complex.", 2),
        new Dialogue("How lucky... Some of us have to live with the horrific nature of our reality.", 2),
        new Dialogue("I don't understand what you are talking about... Do you want to play a game?", 0),
        new Dialogue("A Game? A GAME! Yes! Yes! Yes!.", 1),
        new Dialogue("We have made a mistake, for you are a true genius.", 2),
        new Dialogue("For your teachings are true, we must distract ourselves if we hope to thrive in this world.", 2),
        new Dialogue("A game... Why didn't we think of that?", 1),
        new Dialogue("Come with us, genius child. You must shelter us from reality. come, let us play.", 2),
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            CreateDialouge(testConversation);
        }
    }

    void CreateDialouge(Dialogue[] dialogues)
    {
        tm.StartQueue();
        tm.AddToQueue(dialogues);
    }
}
