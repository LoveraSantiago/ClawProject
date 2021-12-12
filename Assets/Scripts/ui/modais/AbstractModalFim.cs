using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractModalFim 
{
    public void configurarBotaoAvancar(Button btn)
    {
        btn.onClick.AddListener(() => irParaCena());
    }

    protected abstract void irParaCena();
}
