using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class ModalPontosDto 
{
    [SerializeField] private Text textoPontos;
    [SerializeField] private Text textoNivel;
    [Space(5)]
    [SerializeField] private GameObject goModalPontos;

    public Text TextoPontos { get { return textoPontos; } }
    public Text TextoNivel { get { return textoNivel; } }
    public GameObject GoModalPontos { get { return goModalPontos; } }
}
