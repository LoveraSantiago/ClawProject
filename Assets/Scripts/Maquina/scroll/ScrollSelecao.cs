public class ScrollSelecao : AcaoItemEscolhido<PowerUpBtnInfo>.ProdutorEvento
{
    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollSelecao()
    {
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
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
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(0);
        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    private void produzirEventoPupEscolhido(int indiceBtn, PowerUpEntidade pupEscolhido)
    {
        if (pupEscolhido != null)
        {
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
            produtorDeEvento.produziuEvento(pupBtnInfo);
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
