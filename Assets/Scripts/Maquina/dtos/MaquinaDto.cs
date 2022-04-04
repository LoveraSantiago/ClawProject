using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] private float factorHdr;
    [SerializeField] private Transform referenciaChao;    
    [Space(5)]
    [SerializeField] private JoystickDto joystickDto;
    [SerializeField] private MesaJoystickDto mesaJoystickDto;
    [Space(5)]    
    [SerializeField] private DisplaysSlotsDto displaysSlotsDto;    
    [Space(5)]
    [SerializeField] private DisplayTimerDto displayTimerDto;
    [Space(5)]
    [SerializeField] private DisplayDeScoreDto displayDeScoreDto;
    [Space(5)]
    [SerializeField] private BotoesPowerUpDto botoesPowerUpDto;
    [Space(5)]
    [SerializeField] private BotaoLigaDesligaDto botaoLigaDesligaDto;    
    [Space(5)]    
    [SerializeField] private VigaDto vigaLadoEsquerdoDto;
    [SerializeField] private VigaDto vigaLadoDireitoDto;
    [Space(5)]
    [SerializeField] private BordasFrenteDto bordasFrenteDto;
    [Space(5)]
    [SerializeField] private TuboDto tuboDto;
    [Space(5)]
    [SerializeField] private ChaoDto chaoDto;
    [Space(5)]
    [SerializeField] private BarraDto barraDto;
    [Space(5)]
    [SerializeField] private PartesMaquinaDto partesDto;

    public float FactorHdr { get { return factorHdr; } }
    public Transform ReferenciaChao { get { return referenciaChao; } }

    public JoystickDto JoystickDto { get { return joystickDto; } }
    public MesaJoystickDto MesaJoystickDto { get { return mesaJoystickDto; } }

    public DisplaysSlotsDto DisplaysSlotsDto { get { return displaysSlotsDto; } }        

    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    public DisplayTimerDto DisplayTimerDto { get { return displayTimerDto; } }
    
    public BotoesPowerUpDto BotoesPowerUpDto { get { return botoesPowerUpDto; } }
    public BotaoLigaDesligaDto BotaoLigaDesligaDto { get { return botaoLigaDesligaDto; } }
    
    public VigaDto VigaLadoEsquerdoDto { get { return vigaLadoEsquerdoDto; } }
    public VigaDto VigaLadoDireitoDto  { get { return vigaLadoDireitoDto; } }

    public BordasFrenteDto BordasFrenteDto { get { return bordasFrenteDto; } }
    public TuboDto TuboDto { get { return tuboDto; } }
    public ChaoDto ChaoDto { get { return chaoDto; } }
    public BarraDto BarraDto { get { return barraDto; } }

    public PartesMaquinaDto PartesDto { get { return partesDto; } }
}
