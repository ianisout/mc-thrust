using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    CinemachineTransposer vm_transposer;

    Landing landing;
    bool landingStatus;

    void Start()
    {   
        landing = FindObjectOfType<Landing>();

        vm_transposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        landingStatus = landing.GetIsInsideLandingArea();

        if (landingStatus)
        {
            vm_transposer.m_FollowOffset = new Vector3(0.5f, 2.7f, -7f);
        }
    }
}
