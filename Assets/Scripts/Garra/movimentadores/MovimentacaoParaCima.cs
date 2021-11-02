public class MovimentacaoParaCima : MovimentadorProdutorInformacaoGarra
{
    private readonly int ACAO_NORMAL  = 0;
    private readonly int ACAO_ESPERAR = 1;

    private int acaoAtual;
    private int contadorDeSubidas;    

    public MovimentacaoParaCima()
    {
        contadorDeSubidas = 0;        
    }

    public override void preInicio()
    {
        colocarMassa(3);        

        contadorDeSubidas++;
        produtorEventoInfoGarra.produziuEvento(new InformacoesDaGarraDto(contadorDeSubidas));
        playAnimacaoIrPBaixo();        
    }

    public override void update(InputGame inputGame)
    {        
        if(isAcimaPosInicial())
        {
            colocarNaAlturaInicial();
            voltando();
            if(acaoAtual == ACAO_NORMAL)
            {
                comunicadorComGerMovimentacao.trocarParaAcaoNormal();
            }
            else
            {
                comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
            }
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
    }

    public void toAcaoNormal()
    {
        acaoAtual = ACAO_NORMAL;
    }

    public void toAcaoEsperar()
    {
        acaoAtual = ACAO_ESPERAR;
    }   
}
