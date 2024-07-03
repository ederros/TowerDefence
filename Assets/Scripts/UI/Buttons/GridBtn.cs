using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBtn : MonoBehaviour
{
    [SerializeField] TilemapRenderer _renderer;

    public void ChangeGrid()
    {
       
        _renderer.maskInteraction = _renderer.maskInteraction == SpriteMaskInteraction.None ? SpriteMaskInteraction.VisibleInsideMask : SpriteMaskInteraction.None;
        
    }
}
