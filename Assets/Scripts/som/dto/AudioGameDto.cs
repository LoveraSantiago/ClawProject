using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioGameDto : AudioDto
{    
    [Space(3)]
    [SerializeField] private AudioClipDto somCombinacaoOK;
    [SerializeField] private AudioClipDto somCombinacaoNOK;
    [SerializeField] private AudioClipDto somColetado;
    [Space(3)]
    [SerializeField] private AudioClipDto somGarraAgarrada;
    [SerializeField] private AudioClipDto somGarraLateral;
    [SerializeField] private AudioClipDto somGarraInicioDescida;
    [Space(3)]
    [SerializeField] private AudioClipDto somMaqColetaveis;
    [SerializeField] private AudioClipDto somMaqAlarme;
 
    public AudioClipDto SomCombinacaoOK { get { return somCombinacaoOK; } }
    public AudioClipDto SomCombinacaoNOK { get { return somCombinacaoNOK; } }
    public AudioClipDto SomColetado { get { return somColetado; } }
    public AudioClipDto SomGarraAgarrada { get { return somGarraAgarrada; } }
    public AudioClipDto SomGarraLateral { get { return somGarraLateral; } }
    public AudioClipDto SomGarraInicioDescida { get { return somGarraInicioDescida; } }
    public AudioClipDto SomMaqColetaveis { get { return somMaqColetaveis; } }
    public AudioClipDto SomMaqAlarme { get { return somMaqAlarme; } }
}
