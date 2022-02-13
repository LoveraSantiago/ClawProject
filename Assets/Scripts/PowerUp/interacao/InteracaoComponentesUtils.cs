public class InteracaoComponentesUtils 
{
    public static bool isInteracaoComGarra(InteracaoPupComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoComGarra);
    }

    public static bool isInteracaoComDisplayColetado(InteracaoPupComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoDisplayColetado);
    }

    public PowerUpInteracaoComGarra getAsInteracaoComGarra(InteracaoPupComComponente interacao)
    {
        if (isInteracaoComGarra(interacao))
        {
            return (PowerUpInteracaoComGarra)interacao;
        }
        else
        {
            return null;
        }
    }

    public PowerUpInteracaoDisplayColetado getAsInteracaoComDisplayColetado(InteracaoPupComComponente interacao)
    {
        if (isInteracaoComDisplayColetado(interacao))
        {
            return (PowerUpInteracaoDisplayColetado)interacao;
        }
        else
        {
            return null;
        }
    }
}
