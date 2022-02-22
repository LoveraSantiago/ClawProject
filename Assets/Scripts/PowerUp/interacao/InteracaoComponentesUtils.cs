public class InteracaoComponentesUtils 
{
    public static bool isInteracaoComGarra(InteracaoPowerUpComComponente interacao)
    {
        return typeof(PowerUpInteracaoComGarra).IsAssignableFrom(interacao.GetType());        
    }

    public static bool isNotInteracaoComGarra(InteracaoPowerUpComComponente interacao)
    {
        return !isInteracaoComGarra(interacao);
    }

    public static bool isInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
    {
        return typeof(PowerUpInteracaoComDisplayColetado).IsAssignableFrom(interacao.GetType());        
    }

    public static PowerUpInteracaoComGarra getAsInteracaoComGarra(InteracaoPowerUpComComponente interacao)
    {
        if (isInteracaoComGarra(interacao))
        {
            return (PowerUpInteracaoComGarra)interacao;
        }
        else
        {
            return new PowerUpInteracaoComGarraVazio();
        }
    }

    public static PowerUpInteracaoComDisplayColetado getAsInteracaoComDisplayColetado(InteracaoPowerUpComComponente interacao)
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
