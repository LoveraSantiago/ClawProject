using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BoardDto
{  
    public List<Sprite> characters = new List<Sprite>();
    public SpriteRenderer spriteTile;
    public int xSize, ySize;
    public float shakeTile;
    public Transform startBoard;
}
