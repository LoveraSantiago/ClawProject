using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioPupDto : AudioDto
{
    [SerializeField] private AudioClipDto somClique;

    public AudioClipDto SomClique { get { return somClique; } }
}
