using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interaction : MonoBehaviour , IInteractable
{
    [SerializeField] string text;

    public string Text => text;

    public bool Interact(Interactor interactor)
    {
        return true;
    }

    public void Reaction()
    {
        Debug.Log("Esto indica que le he dado a la E");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
