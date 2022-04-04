using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];    
    [Space(5)]        
    [SerializeField] private GameObject areaDraggavel;
    [Space(5)]
    [SerializeField] private GameObject efeitoHolograma;
    [Space(2)]
    [SerializeField] private BotaoPowerUpDto[] btnPowerUp = new BotaoPowerUpDto[2];
    [SerializeField] private BotaoPowerUpDtoV2[] btnPowerUpV2 = new BotaoPowerUpDtoV2[2];

    public Sprite[] BordasBtns { get { return bordasBtns;  } }       

    public GameObject AreaDraggavel { get { return areaDraggavel; } }    
    public GameObject EfeitoHolograma { get { return efeitoHolograma; } }

    public BotaoPowerUpDto[] BtnPowerUp { get { return btnPowerUp;  } }
    public BotaoPowerUpDtoV2[] BtnPowerUpV2 { get { return btnPowerUpV2;  } }
}
