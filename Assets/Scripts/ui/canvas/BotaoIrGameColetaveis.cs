using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoIrGameColetaveis 
{
    public BotaoIrGameColetaveis(Button btnColetavel)
    {
        btnColetavel.onClick.AddListener(() => irParaLevelDeColetado());
    }

    private void irParaLevelDeColetado()
    {
        PlayerPrefsLevel.salvarLevel(Level.COLETAVEL);        
    }
}
