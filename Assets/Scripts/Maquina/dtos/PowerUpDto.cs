using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];
    [SerializeField] private GameObject[] btnsPowerUp = new GameObject[4];

    public Sprite[] BordasBtns { get { return bordasBtns;  } }
    public GameObject[] BtnsPowerUp { get { return btnsPowerUp; } }
}
