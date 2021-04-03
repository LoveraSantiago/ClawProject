using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]

public class BoardManagerDto
{  
    public List<Sprite> characters = new List<Sprite>();
    public GameObject tile;
    public SpriteRenderer sprTile;
    public int xSize, ySize;
    public float shakeTile;
    public Transform transform;
}
