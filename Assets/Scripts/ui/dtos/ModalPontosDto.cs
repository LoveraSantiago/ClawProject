using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalPontosDto 
{
    [SerializeField] private Text textoNivel;
    [SerializeField] private Text textoPontos;
    [SerializeField] private Button btnAvancar;
    [Space(3)]
    [SerializeField] private GameObject goModalPontos;
    [Space(3)]
    [SerializeField] private LinhaModalPontosDto[] linhas = new LinhaModalPontosDto[4];

    public Text TextoNivel { get { return textoNivel; } }
    public Text TextoPontos { get { return textoPontos; } }
    public Button BtnAvancar { get { return btnAvancar; } }
    public GameObject GoModalPontos { get { return goModalPontos; } }
    public LinhaModalPontosDto[] Linhas { get { return linhas; } }
    
}
