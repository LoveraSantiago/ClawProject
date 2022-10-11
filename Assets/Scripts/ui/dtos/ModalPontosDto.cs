using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalPontosDto 
{
    [SerializeField] private Text textoNivel;
    [SerializeField] private Text textoTempo;
    [SerializeField] private Text textoPontos;
    [Space(3)]
    [SerializeField] private Button btnAvancar;
    [Space(3)]
    [SerializeField] private GameObject goModalPontos;
    [Space(3)]
    [SerializeField] private Color corEstrela;
    [SerializeField] private LinhaChallengeDto[] linhasChallenges = new LinhaChallengeDto[3];

    public Text TextoNivel { get { return textoNivel; } }
    public Text TextoPontos { get { return textoPontos; } }
    public Text TextoTempo { get { return textoTempo; } }
    public Button BtnAvancar { get { return btnAvancar; } }
    public GameObject GoModalPontos { get { return goModalPontos; } }
    public Color CorEstrela { get { return corEstrela; } }
    public LinhaChallengeDto[] LinhasChallenges { get { return linhasChallenges; } }

}
