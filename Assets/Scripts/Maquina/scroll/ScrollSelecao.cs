public class ScrollSelecao : AcaoPupFromScrollSelecao.ProdutorEvento
{
    private ProdutorDeEvento<PowerUpBtnInfoDto> produtorDeEvento;

    public ScrollSelecao()
    {
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfoDto>();
    }

    public void selecionouIndicePup(int indiceBtn, int indicePup)
    {
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        produzirEventoPupEscolhido(indiceBtn, pupEscolhido);
    }

    public void selecionouPup(int indiceBtn, PowerUpEnums.TIPO tipoPup)
    {
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipoPup);
        produzirEventoPupEscolhido(indiceBtn, pupEscolhido);
    }

    public void cancelouSelecao()
    {
        PowerUpBtnInfoDto pupBtnInfo = new PowerUpBtnInfoDto(0);
        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    private void produzirEventoPupEscolhido(int indiceBtn, PowerUpEntidade pupEscolhido)
    {
        if (pupEscolhido != null)
        {
            PowerUpBtnInfoDto pupBtnInfo = new PowerUpBtnInfoDto(indiceBtn, pupEscolhido);
            produtorDeEvento.produziuEvento(pupBtnInfo);
        }
    }

    ProdutorDeEvento<PowerUpBtnInfoDto> AcaoPupFromScrollSelecao.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
