using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;


    [SerializeField] private InteractionCanva canva;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Collider[] coll = Physics.OverlapSphere(this.transform.position + pos, radius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].GetComponent<IInteractable>() != null)
            {
                IInteractable interact = coll[i].GetComponent<IInteractable>();

                if (!canva.On)
                {
                    canva.Open(interact.Text);
                    if (Accion())
                    {
                        interact.Reaction();
                    }
                }
                break;
            }
            else
            {
                canva.Close();
            }

        }
    }

    private bool Accion()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + pos, radius);
    }
}
