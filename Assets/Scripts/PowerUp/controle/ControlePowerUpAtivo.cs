public class ControlePowerUpAtivo : ControlePowerUp
{
    private IntervaloDeTempo intervaloFimTempo;
    private PowerUpAcaoExpirado pupExpiracao;

    public ControlePowerUpAtivo(PowerUpInfoDto pupInfo)
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
