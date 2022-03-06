using System.Collections;

public abstract class SelecaoDeAlvos<T>
{
    public void ligarMiras(bool filtrarGaiolas)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis(filtrarGaiolas);        
    }

    public void ligarMiraFinal(Coletavel coletavelSelecionado)
    {
        if (coletavelSelecionado != null)
        {
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
        }        
    }

    public abstract IEnumerator onSelecionar(bool filtrarGaiolas, InputGame inputGame, Transformador<T, IEnumerator> coroutineOnSelecionado);
}
