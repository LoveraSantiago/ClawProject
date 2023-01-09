using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioPupDto : AudioDto
{
    [SerializeField] private AudioClipDto somCliqueVoltar;
    [SerializeField] private AudioClipDto somClique;
    [SerializeField] private AudioClipDto somCliqueCard;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
    public AudioClipDto SomClique { get { return somClique; } }
    public AudioClipDto SomCliqueCard { get { return somCliqueCard; } }
}
