using UnityEngine.UI;

public abstract class AbstractModalFim 
{
    public void configurarBotaoAvancar(Button btn)
    {
        btn.onClick.AddListener(() => irParaCena());
    }

    protected abstract void irParaCena();

    public virtual void ligar(){}
}
