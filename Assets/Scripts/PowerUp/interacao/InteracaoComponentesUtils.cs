public class InteracaoComponentesUtils 
{
    public static bool isInteracaoComGarra(InteracaoPowerUpComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoComGarra);
    }

    public static bool isInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
    {
        return interacao.GetType() == typeof(PowerUpInteracaoComDisplayColetado);
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

    public PowerUpInteracaoComDisplayColetado getAsInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
    {
        if (isInteracaoComDisplayColetado(interacao))
        {
            return (PowerUpInteracaoComDisplayColetado)interacao;
        }
        else
        {
            return null;
        }
    }
}
