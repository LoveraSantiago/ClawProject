using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioMapDto : AudioDto
{
    [SerializeField] private AudioClipDto bumpBaloesLevels;
    [SerializeField] private AudioClipDto cliqueSomSetas;
    [SerializeField] private AudioClipDto cliqueSomBalao;
    [SerializeField] private AudioClipDto cliqueSomCancelar;
    [SerializeField] private AudioClipDto clique;
    [SerializeField] private AudioClipDto abrirModal;
    [SerializeField] private AudioClipDto somStart;

    public AudioClipDto BumpBaloesLevels { get { return bumpBaloesLevels; } }
    public AudioClipDto CliqueSomSetas { get { return cliqueSomSetas; } }
    public AudioClipDto CliqueSomBalao { get { return cliqueSomBalao; } }
    public AudioClipDto CliqueSomCancelar { get { return cliqueSomCancelar; } }
    public AudioClipDto Clique { get { return clique; } }
    public AudioClipDto AbrirModal { get { return abrirModal; } }
    public AudioClipDto SomStart { get { return somStart; } }
    

}
