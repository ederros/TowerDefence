using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Joystick
{
    public class HideableDynamicJoystick : JoystickHandler
    {
        private void Awake() {
            backGround.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            for(int i = 0; i < Input.touchCount; i++)
            {
                if(Input.touches[i].phase == TouchPhase.Began) 
                {
                    backGround.transform.position = Input.touches[i].position;
                    break;
                }
            }
            backGround.gameObject.SetActive(true);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            backGround.gameObject.SetActive(false);
        }
    }
}