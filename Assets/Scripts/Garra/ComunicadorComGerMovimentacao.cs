using UnityEngine;

public interface ComunicadorComGerMovimentacao
{
    void trocarParaAcaoNormal();
    void trocarParaAcaoSubindo();
    void trocarParaAgarrada();
    void trocarParaAcaoDescendo(Vector2 posicaoInicial);
}
