using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] protected Transform head;
    
    public Transform Head => head;
    
}
