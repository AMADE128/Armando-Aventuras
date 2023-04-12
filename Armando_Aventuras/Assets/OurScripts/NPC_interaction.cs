using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_interaction : MonoBehaviour , IInteractable
{
    [SerializeField] string text;
    [SerializeField] private NPCConversation conversation;
    public string Text => text;

    public bool Interact(Interactor interactor)
    {
        return true;
    }

    public void Reaction()
    {
        Debug.Log("Esto indica que le he dado a la E");
    }

    
}
