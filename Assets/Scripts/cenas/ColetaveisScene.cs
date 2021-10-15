using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable 0649
public class ColetaveisScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private Image[] grupoColetaveis = new Image[7]; 

    // Start is called before the first frame update
    void Start()
    {
        configBtnBack(btnBack);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
