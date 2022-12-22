using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    BoxCollider landingArea;
    Rigidbody player;
    Camera followCamera;

    public bool isInsideLandingArea;

    void Start()
    {
        isInsideLandingArea = false;
    }

    void OnTriggerEnter(Collider player) 
    {
        isInsideLandingArea = true;
    }

    void OnTriggerExit(Collider player)
    {
        isInsideLandingArea = false;       
    }

    public bool GetIsInsideLandingArea()
    {
        return isInsideLandingArea;
    }
}
