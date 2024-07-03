using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseViewCloser : ObjectDestroyer
{
    [SerializeField] private bool _pauseStateAfterDestroy;
    public override void Destroy()
    {
        base.Destroy();
        PauseManager.SetPause(_pauseStateAfterDestroy);
    }
}
