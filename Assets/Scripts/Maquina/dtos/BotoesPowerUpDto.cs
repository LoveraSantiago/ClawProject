using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];
    [Space(5)]
    [SerializeField] private GameObject[] btnsPowerUp = new GameObject[4];
    [Space(5)]
    [SerializeField] private Sprite[] spritesDeBotoes;

    public Sprite[] BordasBtns { get { return bordasBtns;  } }
    public GameObject[] BtnsPowerUp { get { return btnsPowerUp; } }
    public Sprite[] SpritesDeBotoes { get { return bordasBtns; } }
}
