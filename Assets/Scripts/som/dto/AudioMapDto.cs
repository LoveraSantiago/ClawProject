using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioMapDto : AudioDto
{
    [SerializeField] private AudioClipDto bumpBaloesLevels;

    public AudioClipDto BumpBaloesLevels { get { return bumpBaloesLevels; } }


}
