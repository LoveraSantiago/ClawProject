using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioDto 
{
    [SerializeField] private AudioSource mainAudioSource;    
    [Space(3)]
    [SerializeField] private AudioClipDto somBackground;
    [SerializeField] private AudioClipDto somGarra;
    [SerializeField] private AudioClipDto somBatidaAbrirModal;    

    public AudioSource MainAudioSource { get { return mainAudioSource; } }
    public GameObject GoAudioSource { get { return mainAudioSource.gameObject; } }

    public AudioClipDto SomBackground { get { return somBackground; } }
    public AudioClipDto SomGarra { get { return somGarra; } }
    public AudioClipDto SomBatidaAbrirModal { get { return somBatidaAbrirModal; } }
    
}
