using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{   
    [SerializeField] private Transform referenciaChao;    
    [Space(3)]
    [SerializeField] private MesaJoystickDto mesaJoystickDto;
    [Space(3)]    
    [SerializeField] private DisplaysColetadosDto displaysColetadosDto;    
    [Space(3)]
    [SerializeField] private DisplayTimerDto displayTimerDto;
    [Space(3)]
    [SerializeField] private DisplayDeScoreDto displayDeScoreDto;
    [Space(3)]
    [SerializeField] private BotoesPowerUpDto botoesPowerUpDto;
    [Space(3)]
    [SerializeField] private BotaoLigaDesligaDto botaoLigaDesligaDto;                
    [Space(3)]
    [SerializeField] private ScrollPupsDto scrollPupsDto;
    [Space(3)]
    [SerializeField] private PartesMaquinaDtoV2 partesDtoV2;
    [Space(3)]
    [SerializeField] private MaquinaEfeitoGlowDto maquinaEfeitoGlow;
    
    public Transform ReferenciaChao { get { return referenciaChao; } }

    public MesaJoystickDto MesaJoystickDto { get { return mesaJoystickDto; } }

    public DisplaysColetadosDto DisplayColetadosDto { get { return displaysColetadosDto; } }        

    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    public DisplayTimerDto DisplayTimerDto { get { return displayTimerDto; } }
    
    public BotoesPowerUpDto BotoesPowerUpDto { get { return botoesPowerUpDto; } }
    public BotaoLigaDesligaDto BotaoLigaDesligaDto { get { return botaoLigaDesligaDto; } }    

    
    public ScrollPupsDto ScrollPupsDto { get { return scrollPupsDto; } }
    public PartesMaquinaDtoV2 PartesDtoV2 { get { return partesDtoV2; } }

    public MaquinaEfeitoGlowDto MaquinaEfeitoGlowDto { get { return maquinaEfeitoGlow; } }
}
