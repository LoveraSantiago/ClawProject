using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioPupDto : AudioDto
{
    [SerializeField] private AudioClipDto somCliqueVoltar;
    [SerializeField] private AudioClipDto somClique;
    [SerializeField] private AudioClipDto somCliqueItem;
    [SerializeField] private AudioClipDto somCliqueCard;
    [SerializeField] private AudioClipDto somStartGame;
    [SerializeField] private AudioClipDto somCancelar;
    [SerializeField] private AudioClipDto abrirModal;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
    public AudioClipDto SomClique { get { return somClique; } }
    public AudioClipDto SomCliqueItem { get { return somCliqueItem; } }
    public AudioClipDto SomCliqueCard { get { return somCliqueCard; } }
    public AudioClipDto SomStartGame { get { return somStartGame; } }
    public AudioClipDto SomCancelar { get { return somCancelar; } }
    public AudioClipDto AbrirModal { get { return abrirModal; } }
}
