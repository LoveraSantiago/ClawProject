using UnityEngine;

public abstract class ScrollMovimentador<T>
{
    private float ultimaPosicao;

    public ScrollMovimentador()
    {
        ultimaPosicao = 1;
    }

    public void movimentado(Vector2 posicao, T dto)
    {
        float result = ultimaPosicao - posicao.y;
        if (result > 0)
        {
            movimentarParaBaixo(dto);
        }
        else if (result < 0)
        {
            movimentarParaCima(dto);
        }
        ultimaPosicao = posicao.y;
    }

    public abstract void movimentarParaCima(T dto);
    public abstract void movimentarParaBaixo(T dto);
}
