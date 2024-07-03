using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] private Rigidbody2D _myRigidBody;
    [SerializeField] protected float _speed = 5f;

    [SerializeField] protected float distanceToLinear = 2;

    private Transform originalTarget;

    public float Speed { get => _speed; set => _speed = value; }

    private void Start() 
    {
        originalTarget = _target;
    }

    public void SetTarget(Transform targ)
    {
        _target = targ;
    }
    public Transform GetTarget() => _target;

    protected virtual Vector2 GetTargetPosition()
    {
        if(_target == null) _target = originalTarget;
        return _target.position;
    }
    virtual protected void Update() 
    {
        _myRigidBody.velocity = transform.up * _speed;
        
        float time = 0.5f;
        

        Vector2 d = Vector2.Distance(GetTargetPosition(), transform.position) > distanceToLinear? (Vector3)GetTargetPosition() * time * time + transform.position * (1 - time) * (1 - time) + 2 * time * (1-time) * new Vector3(transform.position.x, GetTargetPosition().y) : GetTargetPosition();
        transform.up = (Vector3)d - transform.position;

    }
}
