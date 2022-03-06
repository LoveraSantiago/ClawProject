using System.Collections;

public interface SelecaoDeAlvos<T> 
{
    IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<T, IEnumerator> coroutineConsumidora);
}
