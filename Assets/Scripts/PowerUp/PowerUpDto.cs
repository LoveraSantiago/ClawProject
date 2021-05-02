using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{
    [SerializeField] private Sprite spriteBomb;
    [SerializeField] private GameObject tileBomb;

    public Sprite SpriteBomb { get { return spriteBomb; } }
    public GameObject TileBomb { get { return tileBomb; } }
}
