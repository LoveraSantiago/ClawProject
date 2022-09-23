using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class BotoesNavegacaoMapaDto 
{
    [SerializeField] private Button btnNavegacaoEsquerda;
    [SerializeField] private Button btnNavegacaoDireita;
    [SerializeField] private GameObject goExclamacao;

    public Button BtnNavegacaoEsquerda { get { return btnNavegacaoEsquerda; } }
    public Button BtnNavegacaoDireita { get { return btnNavegacaoDireita; } }
    public GameObject GoExclamacao { get { return goExclamacao; } }
}
