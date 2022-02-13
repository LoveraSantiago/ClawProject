public class InteracaoComponentesUtils 
{
    public static bool isInteracaoComGarra(InteracaoPupComComponente interacao)
    {
        return interacao.GetType() == typeof(PupInteracaoComGarra);
    }

    public static bool isInteracaoComDisplayColetado(InteracaoPupComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoDisplayColetado);
    }

    public PupInteracaoComGarra getAsInteracaoComGarra(InteracaoPupComComponente interacao)
    {
        if (isInteracaoComGarra(interacao))
        {
            return (PupInteracaoComGarra)interacao;
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
