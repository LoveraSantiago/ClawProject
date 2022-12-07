using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LinhasChallengeDto 
{
    [SerializeField] private Material materialEstrelaLigada;
    [Space(3)]
    [SerializeField] private LinhaChallengeDto[] linhaChallenges = new LinhaChallengeDto[3];

    public Material MaterialEstrelaLigada { get { return materialEstrelaLigada; } }
    public LinhaChallengeDto[] LinhaChallenges { get { return linhaChallenges; } }
}
