using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInstance : MonoBehaviour
{
    private static CameraInstance instance;
    public static CameraInstance Instance => instance;
    [SerializeField] private Camera cam;
    public Camera Cam => cam;
    private void Awake() 
    {
        instance = this;
    }
}
