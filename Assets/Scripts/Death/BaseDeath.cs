using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BaseDeath : Death
{
    protected override void Die(GameObject targ)
    {
        SceneManager.LoadScene(0);
    }
}
