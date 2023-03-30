using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;


    CinemachineVirtualCamera camera;

    private void Start()
    {
        camera = GetComponent<CinemachineVirtualCamera>();


    }

}
