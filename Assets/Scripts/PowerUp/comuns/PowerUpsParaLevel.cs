public class PowerUpsParaLevel 
{
    private int[] acionamentosAtuais;        
    private PowerUpEnums.TIPO[][] pupsParaLevel;

    public PowerUpsParaLevel(int qtdBotoes)
    {
        pupsParaLevel = new PowerUpEnums.TIPO[qtdBotoes][];
        acionamentosAtuais = new int[qtdBotoes];
    }

    public PowerUpsParaLevel addPupsParaBtn(int indiceBtn, PowerUpEnums.TIPO[] tipos)
    {
        pupsParaLevel[indiceBtn] = tipos;
        return this;
    }

    public PowerUpEnums.TIPO getPupEntidade(int indiceBtn)
    {
        PowerUpEnums.TIPO pupTipo = PowerUpEnums.TIPO.NONE;
        if (deveRecuperarPup(indiceBtn))
        {
            pupTipo = getPupEntidadeFromAcionamento(indiceBtn);            
        }
        return pupTipo;       
    }

    public int getQtdBotoes()
    {
        return acionamentosAtuais.Length;
    }

    private bool deveRecuperarPup(int indiceBtn)
    {
        return isIndiceValido(indiceBtn) && 
               temPupsParaOIndice(indiceBtn) && 
               isAcionamentoAtualValido(indiceBtn);
    }

    private bool isIndiceValido(int indiceBtn)
    {
        return indiceBtn < acionamentosAtuais.Length;
    }

    private bool temPupsParaOIndice(int indiceBtn)
    {
        PowerUpEnums.TIPO[] pupsBtn = pupsParaLevel[indiceBtn];
        return pupsBtn != null && pupsBtn.Length > 0;
    }

    private bool isAcionamentoAtualValido(int indiceBtn)
    {
        PowerUpEnums.TIPO[] pupsBtn = pupsParaLevel[indiceBtn];
        int numeroAcionamentos = acionamentosAtuais[indiceBtn];
        return numeroAcionamentos < pupsBtn.Length;
    }

    private PowerUpEnums.TIPO getPupEntidadeFromAcionamento(int indiceBtn)
    {
        PowerUpEnums.TIPO[] pupsBtn = pupsParaLevel[indiceBtn];
        int acionamentoAtual = acionamentosAtuais[indiceBtn];
        PowerUpEnums.TIPO pupTipo = pupsBtn[acionamentoAtual];

        acionamentosAtuais[indiceBtn] = (acionamentoAtual + 1);
        return pupTipo;
    }
}
