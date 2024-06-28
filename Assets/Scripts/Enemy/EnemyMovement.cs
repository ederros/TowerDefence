using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] protected float speed = 5f;

    [SerializeField] protected float distanceToLinear = 2;

    private Transform originalTarget;
    private void Start() {
        originalTarget = target;
    }
    public void SetTarget(Transform targ)
    {
        target = targ;
    }
    public Transform GetTarget() => target;

    protected virtual Vector2 GetTargetPosition() => target.position;
    
    virtual protected void Update() 
    {
        myRB.velocity = transform.up * speed;
        
        float time = 0.5f;
        if(target==null) target = originalTarget;

        Vector2 d = Vector2.Distance(GetTargetPosition(), transform.position) > distanceToLinear? (Vector3)GetTargetPosition() * time * time + transform.position * (1 - time) * (1 - time) + 2 * time * (1-time) * new Vector3(transform.position.x, GetTargetPosition().y) : GetTargetPosition();
        transform.up = (Vector3)d - transform.position;

    }
}
