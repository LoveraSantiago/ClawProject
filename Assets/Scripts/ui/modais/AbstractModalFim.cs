using UnityEngine.UI;

public abstract class AbstractModalFim 
{
    public abstract void configurar(ModalManipulacao modalManipulacao);

    public void configurarBotaoAvancar(Button btn)
    {
        btn.onClick.AddListener(() => irParaCena());
    }

    protected abstract void irParaCena();
}
