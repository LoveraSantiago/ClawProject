using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] private Transform referenciaChao;
    [SerializeField] private Transform hasteJoystick;
    [Space(5)]
    [SerializeField] private DisplayDeColetadoDto displayDeColetadoDto;
    [Space(5)]
    [SerializeField] private DisplayTimerDto displayTimerDto;
    [SerializeField] private DisplayDeScoreDto displayDeScoreDto;
    [Space(5)]
    [SerializeField] private BotoesPowerUpDto botoesPowerUpDto;

    public Transform ReferenciaChao { get { return referenciaChao; } }
    public Transform HasteJoystick { get { return hasteJoystick;  } }

    public DisplayDeColetadoDto DisplayDeColetadoDto { get { return displayDeColetadoDto; } }
    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    public DisplayTimerDto DisplayTimerDto { get { return displayTimerDto; } }
    
    public BotoesPowerUpDto BotoesPowerUpDto { get { return botoesPowerUpDto; } }
}
