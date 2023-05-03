using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Interactor player;
    private NPCConversation CoNPC;
    private ConversationManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<ConversationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.InDialogue())
        {
            //Select option
            if (Input.GetKeyDown(KeyCode.E))
            {
                manager.PressSelectedOption();
            }

            //Option Down
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                manager.SelectNextOption();
            }

            //Option Up 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                manager.SelectPreviousOption();
            }

            if (manager.TheConversationEnd())
            {
                player.endDialogue();
            }
        }
    }

    public void SetDialogue(NPCConversation dialogue)
    {
        CoNPC = dialogue;

        manager.StartConversation(CoNPC);
    }
}
