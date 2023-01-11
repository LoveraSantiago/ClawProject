public class ContadorPowerUpAtivo : ContadorTimeout
{
    private IntervaloDeTempo intervaloFimTempo;
    private PowerUpAcaoExpirado pupExpiracao;

    public ContadorPowerUpAtivo(PowerUpInfo pupInfo)
    {
        intervaloFimTempo = new IntervaloDeTempo(pupInfo.duracaoTempoPupEntidade);
        pupExpiracao = pupInfo.pupEntidadeAcaoExpirado;
    }

    public void contarTimeout()
    {
        if (intervaloFimTempo.contarTempo())
        {
            pupExpiracao.expirar();
        }
    }
}
