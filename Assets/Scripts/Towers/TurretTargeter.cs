using UnityEngine;

public class TurretTargeter : MonoBehaviour
{
    [SerializeField] Finder finder;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Turret turret;
    [SerializeField] private float minTargetOffset;
    private bool isTargeted = false;
    private float lastSign = 0;
    public bool IsTrackedTarget => isTargeted;
    
    
    private void Update() 
    {
        if(finder.Objects.Count <= 0) {
            lastSign = 0;
            isTargeted = false;
            return;
        }
        
        if(finder.Objects[0] == null)
        {
            finder.CheckAndClean();
            return;
        }
        Vector2 to = finder.Objects[0].transform.position - transform.position;
        float targAng = Mathf.Sign(turret.Head.up.x * to.y - turret.Head.up.y * to.x) * rotationSpeed * Time.deltaTime;
        
        isTargeted = Vector2.Angle(to, turret.Head.up) < minTargetOffset;
        //isTargeted = true;

        //isTargeted = turret.Head.up.x * to.x + turret.Head.up.y * to.y > 0 && lastSign != 0 && ((lastSign > 0 && targAng < 0) || (lastSign < 0 && targAng > 0));
        lastSign = targAng;
        Quaternion quaternion = Quaternion.Euler(0, 0, targAng);
        turret.Head.localRotation *= quaternion;
        
        turret.Head.Rotate(0, 0, targAng);

    }
}
