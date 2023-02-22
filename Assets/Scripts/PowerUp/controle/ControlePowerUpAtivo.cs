public class ControlePowerUpAtivo : ControlePowerUp
{
    private IntervaloDeTempo intervaloFimTempo;
    private PowerUpControleExterno pupParaControleExterno;

    public ControlePowerUpAtivo(PowerUpInfoDto pupInfo)
    {
        intervaloFimTempo = new IntervaloDeTempo(pupInfo.duracaoTempoPupEntidade);
        pupParaControleExterno = pupInfo.pupEntidadeAcaoExpirado;
    }

    public void contarTimeout()
    {
        if (intervaloFimTempo.contarTempo())
        {
            pupParaControleExterno.expirar();
        }
    }

    public void continuar()
    {
        pupParaControleExterno.onContinue();
    }

    public void pausar()
    {
        pupParaControleExterno.onPause();
    }
}
