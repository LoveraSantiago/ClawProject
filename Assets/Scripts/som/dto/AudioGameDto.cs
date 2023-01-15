using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioGameDto : AudioDto
{
    [SerializeField] private AudioClipDto somBackgroundPowerUp;
    [Space(3)]
    [SerializeField] private AudioClipDto somCombinacaoOK;
    [SerializeField] private AudioClipDto somCombinacaoNOK;
    [SerializeField] private AudioClipDto somColetado;
    [SerializeField] private AudioClipDto somColetadoCaindo;
    [SerializeField] private AudioClipDto somColetadoNoTubo;
    [Space(3)]
    [SerializeField] private AudioClipDto somGarraAgarrada;
    [SerializeField] private AudioClipDto somGarraLateral;
    [SerializeField] private AudioClipDto somGarraInicioDescida;
    [Space(3)]
    [SerializeField] private AudioClipDto somMaqColetaveis;
    [SerializeField] private AudioClipDto somMaqAlarme;
    [SerializeField] private AudioClipDto somMaqAlarmeTimer;
    [SerializeField] private AudioClipDto somMaqBlinkTimer;
    [SerializeField] private AudioClipDto somMaqCliqueBtn;
    [SerializeField] private AudioClipDto somMaqCliqueScroll;
    [SerializeField] private AudioClipDto somMaqCliqueScrollCancel;
    [Space(3)]
    [SerializeField] private AudioClipDto abrirModal;
    [SerializeField] private AudioClipDto abrirModalSucesso;
    [Space(3)]
    [SerializeField] private AudioClipDto somExplosao;
    [SerializeField] private AudioClipDto somTeleporte;
    [SerializeField] private AudioClipDto somMissil;
    [Space(3)]
    [SerializeField] private AudioClipDto somBackgroundCacaNiquel;
    [SerializeField] private AudioClipDto somSlotCacaNiquel;
    [SerializeField] private AudioClipDto somCoin;

    public AudioClipDto SomBackgroundPowerUp { get { return somBackgroundPowerUp; } }
    public AudioClipDto SomCombinacaoOK { get { return somCombinacaoOK; } }
    public AudioClipDto SomCombinacaoNOK { get { return somCombinacaoNOK; } }
    public AudioClipDto SomColetado { get { return somColetado; } }
    public AudioClipDto SomColetadoCaindo { get { return somColetadoCaindo; } }
    public AudioClipDto SomColetadoNoTubo { get { return somColetadoNoTubo; } }
    public AudioClipDto SomGarraAgarrada { get { return somGarraAgarrada; } }
    public AudioClipDto SomGarraLateral { get { return somGarraLateral; } }
    public AudioClipDto SomGarraInicioDescida { get { return somGarraInicioDescida; } }
    public AudioClipDto SomMaqColetaveis { get { return somMaqColetaveis; } }
    public AudioClipDto SomMaqAlarme { get { return somMaqAlarme; } }
    public AudioClipDto SomMaqAlarmeTimer { get { return somMaqAlarmeTimer; } }
    public AudioClipDto SomMaqBlinkTimer { get { return somMaqBlinkTimer; } }
    public AudioClipDto SomMaqCliqueBtn { get { return somMaqCliqueBtn; } }
    public AudioClipDto SomMaqCliqueScroll { get { return somMaqCliqueScroll; } }
    public AudioClipDto SomMaqCliqueScrollCancel { get { return somMaqCliqueScrollCancel; } }
    public AudioClipDto SomAbrirModal { get { return abrirModal; } }
    public AudioClipDto SomAbrirModalSucesso { get { return abrirModalSucesso; } }
    public AudioClipDto SomExplosao { get { return somExplosao; } }
    public AudioClipDto SomTeleporte { get { return somTeleporte; } }
    public AudioClipDto SomMissil { get { return somMissil; } }

    public AudioClipDto SomBackgroundCacaNiquel { get { return somBackgroundCacaNiquel; } }

    public AudioClipDto SomSlotCacaNiquel { get { return somSlotCacaNiquel; } }
    public AudioClipDto SomCoin { get { return somCoin; } }
}
