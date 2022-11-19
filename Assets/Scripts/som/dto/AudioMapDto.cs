using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioMapDto : AudioDto
{
    [SerializeField] private AudioClipDto bumpBaloesLevels;
    [SerializeField] private AudioClipDto cliqueSomSetas;

    public AudioClipDto BumpBaloesLevels { get { return bumpBaloesLevels; } }
    public AudioClipDto CliqueSomSetas { get { return cliqueSomSetas; } }
    

}
