public class ScrollSelecao : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento
{
    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollSelecao()
    {
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
    }

    public void simularCliqueBoxAcionado(int indiceBtn, int indicePup)
    {
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        simularCliqueBoxAcionado(indiceBtn, pupEscolhido);
    }

    public void simularCliqueBoxAcionado(int indiceBtn, PowerUpEnums.TIPO tipoPup)
    {
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipoPup);
        simularCliqueBoxAcionado(indiceBtn, pupEscolhido);
    }

    private void simularCliqueBoxAcionado(int indiceBtn, PowerUpEntidade pupEscolhido)
    {
        if (pupEscolhido != null)
        {
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
            produtorDeEvento.produziuEvento(pupBtnInfo);
        }
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
