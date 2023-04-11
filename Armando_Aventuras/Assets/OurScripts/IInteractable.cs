using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
   public string Text { get; }

    public bool Interact(Interactor interactor);

    public void Reaction();
}
