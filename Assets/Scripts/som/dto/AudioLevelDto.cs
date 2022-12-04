using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioLevelDto : AudioDto
{
    [Space(3)]
    [SerializeField] private AudioClipDto somCliqueVoltar;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
}
