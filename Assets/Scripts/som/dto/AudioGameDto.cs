using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioGameDto : AudioDto
{
    [SerializeField] private AudioClipDto somBackground;
    [SerializeField] private AudioClipDto somCombinacaoOK;
    [SerializeField] private AudioClipDto somCombinacaoNOK;
    [SerializeField] private AudioClipDto somColetado;

    public AudioClipDto SomBackground { get { return somBackground; } }
    public AudioClipDto SomCombinacaoOK { get { return somCombinacaoOK; } }
    public AudioClipDto SomCombinacaoNOK { get { return somCombinacaoNOK; } }
    public AudioClipDto SomColetado { get { return somColetado; } }
}
