using System.Collections;
using System.Collections.Generic;
using UI.Joystick;
using UnityEngine;

public class PlayerCircleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private JoystickHandler joystick;
    public static PlayerCircleMovement PlayerMovement;

    public void RandomDash()
    {
        rb.AddForce(Random.insideUnitCircle.normalized);
    }
    private void Awake() 
    {
        PlayerMovement = this;
    }
    private void Start() 
    {
        joystick.PointerUpEvent += () => 
        {
            rb.velocity = Vector2.zero;
        };

        joystick.DirectionEvent += (Vector2 dir) => 
        {
            rb.velocity = dir * speed;
        };
    }
}
