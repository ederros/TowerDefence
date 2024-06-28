using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaFitter : MonoBehaviour
{
    void Start()
    {
        float offset = Screen.height - Screen.safeArea.height;
        
        transform.position += Vector3.down * offset;
    }
    private void Update() {
        Debug.Log(Screen.height + " " + Screen.safeArea.height);
    }
}
