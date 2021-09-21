using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalPontosDto 
{
    [SerializeField] private Text textoNivel;
    [SerializeField] private Text textoPontos;
    [Space(3)]
    [SerializeField] private GameObject goModalPontos;
    [Space(3)]
    [SerializeField] private LinhaModalPontos[] linhas = new LinhaModalPontos[4];

    public Text TextoNivel { get { return textoNivel; } }
    public Text TextoPontos { get { return textoPontos; } }
    public GameObject GoModalPontos { get { return goModalPontos; } }
}
