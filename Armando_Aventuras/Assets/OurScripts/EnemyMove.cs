using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerPos;

    private NavMeshAgent navMesh;

    public float minDistance;
    // Start is called before the first frame update
    void Start()
    {
        
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);

        MoveToPlayer();
    }


    private void MoveToPlayer()
    {
        NavMeshHit hit;

        if (!navMesh.Raycast(playerPos, out hit))
        {
            if (hit.distance <= minDistance && hit.distance >= 1)
            {
                navMesh.SetDestination(player.transform.position);

            }
        }
        else
        {
            navMesh.SetDestination(this.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (navMesh != null)
        {

            NavMeshHit hit;

            if (navMesh.Raycast(playerPos, out hit))
            {
                Gizmos.color = Color.red;

            }
            else
            {
                Gizmos.color = Color.green;

            }

            Gizmos.DrawLine(this.transform.position, playerPos);
        }
    }

}
