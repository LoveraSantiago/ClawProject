using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioLevelDto : AudioDto
{
    [Space(3)]
    [SerializeField] private AudioClipDto somCliqueVoltar;
    [SerializeField] private AudioClipDto somCliqueLevel;    

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
    public AudioClipDto SomCliqueLevel { get { return somCliqueLevel; } }    
}
