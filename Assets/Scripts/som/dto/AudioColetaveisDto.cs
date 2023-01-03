using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AudioColetaveisDto : AudioDto
{
    [Space(3)]
    [SerializeField] private AudioClipDto somCliqueVoltar;
    [SerializeField] private AudioClipDto somClique;
    [SerializeField] private AudioClipDto somCliqueColetavel;
    [SerializeField] private AudioClipDto somZoomArmario;
    [SerializeField] private AudioClipDto somStartGame;

    public AudioClipDto SomCliqueVoltar { get { return somCliqueVoltar; } }
    public AudioClipDto SomClique { get { return somClique; } }
    public AudioClipDto SomCliqueColetavel { get { return somCliqueColetavel; } }
    public AudioClipDto SomZoomArmario { get { return somZoomArmario; } }
    public AudioClipDto SomStartGame { get { return somStartGame; } }
    
}
