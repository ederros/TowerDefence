using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionField : MonoBehaviour, IPointerMoveHandler, IPointerDownHandler, IPointerUpHandler
{
    public event Action<Vector2> PointerMoved;
    public event Action<Vector2> PointerUpped;
    private Vector2 position;
    private bool isPtrDown = false;
    public void OnPointerMove(PointerEventData eventData)
    {
        position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPtrDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPtrDown = false;
        PointerUpped?.Invoke(eventData.position);
    }
    private void Update() 
    {
        if(!isPtrDown) return;
        PointerMoved?.Invoke(position);
    }
}
