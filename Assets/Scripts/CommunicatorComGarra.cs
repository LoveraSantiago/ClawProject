using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CommunicatorComGarra
{
    void trocarParaAcaoNormal();
    void trocarParaAcaoSubindo();
    void trocarParaAcaoDescendo(Vector2 posicaoInicial);
}
