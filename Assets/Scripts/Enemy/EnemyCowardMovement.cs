using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCowardMovement : EnemyMovement
{
    private Vector3 _startPos;
    [SerializeField] private float distanceToBase;
    [SerializeField] private float timePause;
    private float _startTime = 0;
    private float _startDistance = 0;
    private Phase curPhase = Phase.moveToBase;
    enum Phase
    {
        moveToBase,
        stay,
        moveOut
    }

    protected override void Start()
    {
        base.Start();
        _startPos = transform.position;
        _startDistance = (transform.position - originalTarget.position).sqrMagnitude;
    }

    protected override Vector2 GetTargetPosition()
    {
        float dist = (transform.position - originalTarget.position).sqrMagnitude;
        Vector2 result = transform.position;
        switch (curPhase)
        {   
            case Phase.moveToBase:
                if(dist < distanceToBase) curPhase = Phase.stay;
                result = base.GetTargetPosition();
                break;

            case Phase.stay:
                if(_startTime == 0)
                    _startTime = Time.time;
                
                if(Time.time > _startTime + timePause)
                    curPhase = Phase.moveOut;
                break;

            case Phase.moveOut:
                if(Mathf.Abs(_startDistance - dist) < 0.01f)
                    Destroy(this.gameObject);
                result = _startPos;
                break;
        }

        return result;
    }
}
