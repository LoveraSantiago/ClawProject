using System.Collections;

public class HumAlvoSelecionado 
{   
    public IEnumerator onSelecionado(InputGame inputGame, Transformador<Coletavel, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavelSelecionado));
    }
}
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS
//TESTAR TIMEOUTS