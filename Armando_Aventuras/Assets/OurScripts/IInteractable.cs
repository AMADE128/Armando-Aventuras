using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string Text { get; }

    public bool CanInteract { get; }

    public bool Interact(Interactor interactor);

    //if return true, start dialogue
    public bool Reaction();

}
