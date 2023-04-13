using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    private IInteractable interact = null;
    private int index = 0;


    [SerializeField] private InteractionCanva canva;

    public bool inDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        interact = null;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
       Collider[] coll = Physics.OverlapSphere(this.transform.position + pos, radius);

        bool find = false;

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].GetComponent<IInteractable>() != null)
            {
                index = i;
                find = true;
                find = coll[i].GetComponent<IInteractable>().CanInteract;
            }
        }
        if (find)
        {
            interact = coll[index].GetComponent<IInteractable>();

            if (!canva.On)
            {
                canva.Open(interact.Text);
                Debug.Log("Algo cerca");
            }
            else
            {
                if (!inDialogue && Input.GetKeyDown(KeyCode.E))
                {
                    inDialogue = interact.Reaction();
                }
            }
        }
        else
        {
            if (canva.On)
            {
                interact = null;
                canva.Close();
            }
        }

        
    }

    public bool InDialogue()
    {
        return inDialogue;
    }

    public void endDialogue()
    {
        inDialogue = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + pos, radius);
    }
}
