using UnityEngine.UI;

public interface MovimentadorDeArmario 
{
    void movimentar(ScrollRect scrollRect, PrateleirasDto prateleirasDto);
    void voltar();
    bool isArmarioMovimentado();
}
