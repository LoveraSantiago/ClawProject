using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class MainLojaDto 
{
    [SerializeField] private Button btnVoltar;
    [Space(5)]
    [SerializeField] private TextMeshProUGUI lblQtdFichasOuro;
    [SerializeField] private TextMeshProUGUI lblQtdFichasPrata;
    [SerializeField] private TextMeshProUGUI lblQtdFichasBronze;
    [Space(5)]
    [SerializeField] private Button btnOuro;
    [SerializeField] private Button btnPrata;
    [SerializeField] private Button btnBronze;
    [Space(5)]
    [SerializeField] private Button btnAssinatura;
    [Space(5)]
    [SerializeField] private AudioLojaDto audioLojaDto;
    [SerializeField] private GameObject prefabLoading;
    [SerializeField] private GameObject[] gosDesligar;

    public Button BtnVoltar { get { return btnVoltar; } }

    public TextMeshProUGUI LblQtdFichasOuro { get { return lblQtdFichasOuro; } }
    public TextMeshProUGUI LblQtdFichasPrata { get { return lblQtdFichasPrata; } }
    public TextMeshProUGUI LblQtdFichasBronze { get { return lblQtdFichasBronze; } }

    public Button BtnOuro { get { return btnOuro; } }
    public Button BtnPrata { get { return btnPrata; } }
    public Button BtnBronze { get { return btnBronze; } }
    public Button BtnAssinatura { get { return btnAssinatura; } }

    public AudioLojaDto AudioLojaDto { get { return audioLojaDto; } }
    public GameObject PrefabLoading { get { return prefabLoading; } }
    public GameObject[] GosDesligar { get { return gosDesligar; } }

}
