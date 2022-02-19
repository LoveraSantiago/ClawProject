using System.Collections;

public interface SelecaoDeAlvos<T> 
{
    IEnumerator onSelecionado(InputGame inputGame, Transformador<T, IEnumerator> coroutineConsumidora);
}
