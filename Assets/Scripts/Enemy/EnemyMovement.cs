using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] private Rigidbody2D _myRigidBody;
    [SerializeField] protected float _speed = 5f;

    [SerializeField] protected float distanceToLinear = 2;
    [SerializeField] protected Finder towers;
    protected Transform originalTarget;

    public float Speed { get => _speed; set => _speed = value; }

    protected virtual void Start() 
    {
        originalTarget = _target;
    }

    public void SetTarget(Transform targ)
    {
        _target = targ;
    }
    public Transform GetTarget() => _target;

    public Transform GetOriginTarget() => originalTarget;

    protected virtual Vector2 GetTargetPosition()
    {
        if(_target == null) _target = originalTarget;
        return _target.position;
    }
    virtual protected void Update() 
    {
        Vector2 targ = GetTargetPosition();
        if(Vector2.SqrMagnitude(targ - (Vector2)transform.position) < 0.01) 
        {
            _myRigidBody.velocity = Vector2.zero;
            return;
        }
        _myRigidBody.velocity = transform.up * _speed;
        
        float time = 0.5f;
        
        if(towers.Objects.Count != 0)
        {
            SetTarget(towers.Objects[0].transform);
        }

        Vector2 d = Vector2.Distance(targ, transform.position) > distanceToLinear? (Vector3)targ * time * time + transform.position * (1 - time) * (1 - time) + 2 * time * (1-time) * new Vector3(transform.position.x, targ.y) : targ;
        transform.up = (Vector3)d - transform.position;

    }
}
