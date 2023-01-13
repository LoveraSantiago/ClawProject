using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioConfigDto : AudioDto
{
    [SerializeField] private AudioClipDto somCliqueVoltar;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
}
