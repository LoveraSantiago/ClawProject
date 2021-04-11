using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpDto 
{
    [SerializeField] private GameObject[] btnsPowerUp = new GameObject[4];

    public GameObject[] BtnsPowerUp { get { return btnsPowerUp; } }
}
