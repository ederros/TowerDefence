using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] Image filledImage;
    [SerializeField] float time;

    public event System.Action Started;
    public event System.Action Ended;
 
    public void SetTime(float time)
    {
        this.time = time;
    }

    /// <summary>
    /// return values between 0 and 1, where 0 is start of cooldown and 1 is end of cooldown.
    /// </summary>
    public event System.Action<float> Processed;

    IEnumerator cooldownCoroutine;

    IEnumerator cooldown()
    {
        Started?.Invoke();
        while (startTime + time > Time.time) 
        {
            yield return new WaitForSeconds(0.05f);
            if(filledImage != null)
                filledImage.fillAmount = 1-(Time.time - startTime) / time;
            Processed?.Invoke((Time.time - startTime) / time);
        }
        Ended?.Invoke();
        cooldownCoroutine = null;
        isCooldowned = false;
    }
    private float startTime = 0;
    private bool isCooldowned = false;

    public bool IsCooldowned => isCooldowned;

    public void StartCooldown()
    {
        startTime = Time.time;
        isCooldowned = true;
        if(cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
            cooldownCoroutine = null;
        }
        cooldownCoroutine = cooldown();
        StartCoroutine(cooldownCoroutine);
    }
}
