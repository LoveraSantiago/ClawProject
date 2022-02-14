public class InteracaoComponentesUtils 
{
    public static bool isInteracaoComGarra(InteracaoPowerUpComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoComGarra);
    }

    public static bool isInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoDisplayColetado);
    }

    public PowerUpInteracaoComGarra getAsInteracaoComGarra(InteracaoPowerUpComComponente interacao)
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

    public PowerUpInteracaoDisplayColetado getAsInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
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
