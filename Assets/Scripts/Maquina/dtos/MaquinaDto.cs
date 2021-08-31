using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] private Transform referenciaChao;
    [Space(5)]
    [SerializeField] private JoystickDto joystickDto;    
    [Space(5)]    
    [SerializeField] private DisplaysSlotsDto displaysSlotsDto;
    [Space(5)]
    [SerializeField] private DisplayTimerDto displayTimerDto;
    [Space(5)]
    [SerializeField] private DisplayDeScoreDto displayDeScoreDto;
    [Space(5)]
    [SerializeField] private BotoesPowerUpDto botoesPowerUpDto;
    [Space(5)]
    [SerializeField] private VigasDto vigasDto;
    [Space(5)]
    [SerializeField] private PartesMaquinaDto partesDto;

    public Transform ReferenciaChao { get { return referenciaChao; } }
    public JoystickDto JoystickDto { get { return joystickDto; } }

    public DisplaysSlotsDto DisplaysSlotsDto { get { return displaysSlotsDto; } }    
    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    public DisplayTimerDto DisplayTimerDto { get { return displayTimerDto; } }
    
    public BotoesPowerUpDto BotoesPowerUpDto { get { return botoesPowerUpDto; } }
    public VigasDto VigasDto { get { return vigasDto; } }
    public PartesMaquinaDto PartesDto { get { return partesDto; } }
}
