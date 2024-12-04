using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distanceMultiplier;
    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void FixedUpdate() 
    {
        Vector3 targetPos = (target.position - _startPos) * distanceMultiplier + _startPos;
        targetPos = Vector2.Lerp(transform.position, targetPos, Time.deltaTime);
        targetPos.z = _startPos.z;
        transform.position = targetPos;
    }
}
