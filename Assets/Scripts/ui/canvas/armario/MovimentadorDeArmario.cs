using UnityEngine.UI;

public interface MovimentadorDeArmario 
{
    void movimentar(ScrollRect scrollRect, PrateleirasDto prateleirasDto);
    void voltar(ScrollRect scrollRect);
    bool isArmarioMovimentado();
}
