using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Joystick
{
    public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] protected Image backGround;
        [SerializeField] protected Image center;
        [SerializeField] protected Color active;
        [SerializeField] protected Color inActive;
        [SerializeField] protected float sensitivity;
        protected Vector2 _inputVector;
        private Vector2 _bgSizeDelta;
        public event Action DragEvent;
        public event Action PointerDownEvent;
        public event Action PointerUpEvent;
        public event Action<Vector2> DirectionEvent;
        public Vector2 Direction => _inputVector;
        private bool _isActive = false;
        private void Start()
        {
            ClickEffect();
            _bgSizeDelta = backGround.rectTransform.sizeDelta;
        }
        private void Update() => DirectionEvent?.Invoke(_inputVector);
        public virtual void OnDrag(PointerEventData eventData)
        {
            DragEvent?.Invoke();
            Vector2 position;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backGround.rectTransform, eventData.position,
                    null, out position))
            {
                position.x *= 2 / _bgSizeDelta.x;
                position.y *= 2 / _bgSizeDelta.y;

                _inputVector = position * sensitivity;
                _inputVector = Vector2.ClampMagnitude(_inputVector, 1);

                center.rectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * _bgSizeDelta.x / 2, 
                    _inputVector.y * _bgSizeDelta.y / 2
                );
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            ClickEffect();
            PointerDownEvent?.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            ClickEffect();
            _inputVector = Vector2.zero;
            center.rectTransform.anchoredPosition = Vector2.zero;
            PointerUpEvent?.Invoke();
        }

        private void ClickEffect()
        {
            center.color = _isActive ? active : inActive;
            _isActive = !_isActive;
        }
    }
}
