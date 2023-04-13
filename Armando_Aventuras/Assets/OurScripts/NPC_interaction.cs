using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_interaction : MonoBehaviour , IInteractable
{
    [SerializeField] string text;
    private NPCConversation conversation;
    [SerializeField] private DialogueManager manager;

    [SerializeField] private bool oneInteraction = false;

    private bool canInteract = true;

    public string Text => text;

    public bool CanInteract => canInteract;

    private void Start()
    {
        conversation = this.GetComponent<NPCConversation>();
    }

    public bool Interact(Interactor interactor)
    {
        return true;
    }

    public bool Reaction()
    {
        Debug.Log("Esto indica que le he dado a la E");

        manager.SetDialogue(conversation);
        if (oneInteraction)
        {
            canInteract = false;
        }

        return true;
    }

    
}
