public abstract class AbstractTutorialPowerUp : AcaoPowerUpAcionado.ConsumidorEvento,
                                                AcaoColetado.ProdutorEvento,
                                                AcaoColetadoFim.ConsumidorEvento
{
    public abstract void iniciar();
    public abstract void consumirEvento(PowerUpInfoDto evento);

    public virtual void consumirEvento(ColetadoFimDto evento){}

    public abstract ProdutorDeEvento<InformacoesColetadoDto> getProdutorDeEvento();
}
