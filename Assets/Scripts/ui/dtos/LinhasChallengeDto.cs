using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LinhasChallengeDto 
{
    [SerializeField] private Color corEstrela;
    [Space(3)]
    [SerializeField] private LinhaChallengeDto[] linhaChallenges = new LinhaChallengeDto[3];

    public Color CorEstrela { get { return corEstrela; } }
    public LinhaChallengeDto[] LinhaChallenges { get { return linhaChallenges; } }
}
