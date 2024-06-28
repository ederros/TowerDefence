using UnityEngine;

public class GoldTower : MonoBehaviour
{
    [SerializeField] float timeToPay;
    [SerializeField] int payCount = 100;
    [SerializeField] private Animator anim;
    private float startTime;

    public event System.Action PayEvent;
    int namehash;
    private void Start() 
    {
        startTime = Time.time;
        namehash = Animator.StringToHash("GoldTower");
    }
    

    private void Update() 
    {
        if(Time.time < startTime + timeToPay) return;
        Money.PlayerMoney.Add(payCount);
        startTime = Time.time;
        PayEvent?.Invoke();
        anim.Play(namehash);
    }
}
