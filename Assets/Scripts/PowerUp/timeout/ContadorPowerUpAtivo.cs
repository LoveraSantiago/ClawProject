public class ContadorPowerUpAtivo : ContadorTimeout
{
    private IntervaloDeTempo intervaloFimTempo;

    public ContadorPowerUpAtivo(int duracaoTempo)
    {
        intervaloFimTempo = new IntervaloDeTempo(duracaoTempo);
    }

    public void contarTimeout(PowerUpAcaoExpirado pupExpiracao)
    {
        if (intervaloFimTempo.contarTempo())
        {
            pupExpiracao.expirar();
        }
    }
}
