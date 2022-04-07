using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaDto
{
    [Space(5)]
    [SerializeField] private float factorHdr;
    [SerializeField] private Transform referenciaChao;    
    [Space(5)]
    [SerializeField] private MesaJoystickDto mesaJoystickDto;
    [Space(5)]    
    [SerializeField] private DisplaysColetadosDto displaysColetadosDto;    
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
    [SerializeField] private TuboDtoV2 tuboDtoV2;
    [Space(5)]
    [SerializeField] private ChaoDto chaoDto;
    [Space(5)]
    [SerializeField] private BarraDto barraDto;
    [SerializeField] private BarraDtoV2 barraDtoV2;
    [Space(5)]
    [SerializeField] private PartesMaquinaDtoV2 partesDtoV2;

    public float FactorHdr { get { return factorHdr; } }
    public Transform ReferenciaChao { get { return referenciaChao; } }

    public MesaJoystickDto MesaJoystickDto { get { return mesaJoystickDto; } }

    public DisplaysColetadosDto DisplayColetadosDto { get { return displaysColetadosDto; } }        

    public DisplayDeScoreDto DisplayDeScoreDto { get { return displayDeScoreDto; } }
    public DisplayTimerDto DisplayTimerDto { get { return displayTimerDto; } }
    
    public BotoesPowerUpDto BotoesPowerUpDto { get { return botoesPowerUpDto; } }
    public BotaoLigaDesligaDto BotaoLigaDesligaDto { get { return botaoLigaDesligaDto; } }
    
    public VigaDto VigaLadoEsquerdoDto { get { return vigaLadoEsquerdoDto; } }
    public VigaDto VigaLadoDireitoDto  { get { return vigaLadoDireitoDto; } }

    public BordasFrenteDto BordasFrenteDto { get { return bordasFrenteDto; } }

    public TuboDto TuboDto { get { return tuboDto; } }
    public TuboDtoV2 TuboDtoV2 { get { return tuboDtoV2; } }

    public ChaoDto ChaoDto { get { return chaoDto; } }

    public BarraDto BarraDto { get { return barraDto; } }
    public BarraDtoV2 BarraDtoV2 { get { return barraDtoV2; } }

    public PartesMaquinaDtoV2 PartesDtoV2 { get { return partesDtoV2; } }
}
