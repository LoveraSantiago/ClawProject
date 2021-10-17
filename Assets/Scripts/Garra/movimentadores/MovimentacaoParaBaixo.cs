using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarraNormal
{   
    private ContadorDeTempo contadorDeTempoTravamento;
    public ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra { get; private set; }

    public MovimentacaoParaBaixo(ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra)
    {
        contadorDeTempoTravamento  = new ContadorDeTempo(1.0f);
        this.produtorEventoInfoGarra = produtorEventoInfoGarra;
    }

    public override void preInicio()
    {   
        colocarMassa(2);
        contadorDeTempoTravamento.resetContador();
        playAnimacaoIrPBaixo();
    }

    public override void update(InputGame inputGame)
    {
        if (contadorDeTempoTravamento.contarTempoDT())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }

    public override void fixedUpdate()
    {
        Quaternion angAberturaEsquerda = angulosTemp.angAberturaEsquerda;
        Quaternion angAberturaDireita  = angulosTemp.angAberturaDireita;

        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloAbertura, angAberturaEsquerda, angAberturaDireita);
        moverParaBaixoFreeze();
    }

    public override void garraColidiuCom(GameObject gameObject)
    {        
        if (UtilsTags.isColetavel(gameObject))
        {
            produtorEventoInfoGarra.produziuEvento(new InformacoesDaGarraDto(gameObject.name));
            comunicadorComGerMovimentacao.trocarParaAcaoAgarrada();
        }
    }   
}
