using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for controlling Main Camera - attached on Main Camera object
/// Following Player with offest
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - objectToFollow.transform.position; 
    }
    void Update()
    {
        transform.position = objectToFollow.transform.position + cameraOffset;
    }


} //class end
