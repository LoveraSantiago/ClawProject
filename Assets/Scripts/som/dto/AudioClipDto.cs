using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioClipDto 
{
    [SerializeField] private float volume;
    [SerializeField] private AudioClip audioClip;

    public float Volume { get { return volume; } }
    public AudioClip AudioClip { get { return audioClip; } }
}
