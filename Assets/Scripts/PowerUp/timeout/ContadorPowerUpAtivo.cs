public class ContadorPowerUpAtivo : ContadorTimeout
{
    private IntervaloDeTempo intervaloFimTempo;
    PowerUpAcaoExpirado pupExpiracao;

    public ContadorPowerUpAtivo(PowerUpInfo pupInfo)
    {
        intervaloFimTempo = new IntervaloDeTempo(pupInfo.duracaoTempo);
        pupExpiracao = pupInfo.pupAcaoExpirado;
    }

    public void contarTimeout()
    {
        if (intervaloFimTempo.contarTempo())
        {
            pupExpiracao.expirar();
        }
    }
}
