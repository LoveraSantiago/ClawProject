using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioTitleDto 
{
    [SerializeField] private AudioSource mainAudioSource;    
    [Space(3)]
    [SerializeField] private AudioClip somBackground;
    [SerializeField] private AudioClip somCliqueBotao;

    public AudioSource MainAudioSource { get { return mainAudioSource; } }
    public GameObject GoAudioSource { get { return mainAudioSource.gameObject; } }

    public AudioClip SomBackground { get { return somBackground; } }
    public AudioClip SomCliqueBotao { get { return somCliqueBotao; } }

}
