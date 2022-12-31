using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioColetaveisDto : AudioDto
{
    [Space(3)]
    [SerializeField] private AudioClipDto somCliqueVoltar;
    [SerializeField] private AudioClipDto somClique;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
    public AudioClipDto SomClique { get { return somClique; } }
}
