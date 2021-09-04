using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];    
    [Space(5)]        
    [SerializeField] private GameObject areaDraggavel;
    [Space(5)]   
    [SerializeField] private BotaoPowerUpDto[] btnPowerUp = new BotaoPowerUpDto[4];

    public Sprite[] BordasBtns { get { return bordasBtns;  } }       

    public GameObject AreaDraggavel { get { return areaDraggavel; } }    

    public BotaoPowerUpDto[] BtnPowerUp { get { return btnPowerUp;  } }
}
