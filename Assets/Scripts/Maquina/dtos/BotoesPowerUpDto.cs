using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotoesPowerUpDto 
{
    [SerializeField] private Sprite[] bordasBtns = new Sprite[2];
    [Space(3)]
    [SerializeField] private SpritesTampaBtnPupDto spritesTampaDto;            
    [Space(3)]        
    [SerializeField] private GameObject areaDraggavel;
    [Space(3)]    
    [SerializeField] private BotaoPowerUpDtoV2[] btnPowerUpV2 = new BotaoPowerUpDtoV2[2];
    [Space(3)]
    [SerializeField] private EfeitoHologramaBtnPupDto efeitoHologramaDto;

    public Sprite[] BordasBtns { get { return bordasBtns;  } }

    public SpritesTampaBtnPupDto SpritesTampaDto { get { return spritesTampaDto; } }

    public GameObject AreaDraggavel { get { return areaDraggavel; } }    
    public BotaoPowerUpDtoV2[] BtnPowerUpV2 { get { return btnPowerUpV2;  } }

    public EfeitoHologramaBtnPupDto EfeitoHologramaDto { get { return efeitoHologramaDto; } }
}
