using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    CinemachineTransposer vm_transposer;

    // Initial tests for first scene experiment

    float initialCamDistance_x = 2.6f;
    float initialCamDistance_y = 4.3f;
    float initialCamDistance_z = -10;

    float camZoom_x = 0.5f;
    float camZoom_y = 2.7f;
    float camZoom_z = -7f;

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
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

/*         if (landing.GetIsInsideLandingArea() && !hasLandedOnce)
        {
            if (initialCamDistance_x > camZoom_x)
            {
                initialCamDistance_x -= 0.01f;
            }

            if (initialCamDistance_y > camZoom_y)
            {
                initialCamDistance_y -= 0.0078f;
            }

            if (initialCamDistance_z < camZoom_z)
            {
                initialCamDistance_z += 0.0145f;
            }

            vm_transposer.m_FollowOffset = new Vector3(initialCamDistance_x, initialCamDistance_y, initialCamDistance_z);
        } */
        

    void ZoomIn()
    {
        if (initialCamDistance_x > camZoom_x)
        {
            initialCamDistance_x -= 0.01f;
        }

        if (initialCamDistance_y > camZoom_y)
        {
            initialCamDistance_y -= 0.0078f;
        }

        if (initialCamDistance_z < camZoom_z)
        {
            initialCamDistance_z += 0.0145f;
        }

        vm_transposer.m_FollowOffset = new Vector3(initialCamDistance_x, initialCamDistance_y, initialCamDistance_z);
    }

    void ZoomOut()
    {
        if (initialCamDistance_x < 2.6f)
        {
            initialCamDistance_x += 0.01f;
        }

        if (initialCamDistance_y < 4.3f)
        {
            initialCamDistance_y += 0.0078f;
        }

        if (initialCamDistance_z > -10)
        {
            initialCamDistance_z -= 0.0145f;
        }

        vm_transposer.m_FollowOffset = new Vector3(initialCamDistance_x, initialCamDistance_y, initialCamDistance_z);
    }
}
