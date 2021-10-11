using UnityEngine;

public class MovimentacaoParaBaixo : MovimentacaoDaGarraNormal
{
    private Quaternion anguloDesejadoEsquerda;
    private Quaternion anguloDesejadoDireita;   
    
    private ContadorDeTempo contadorDeTempoTravamento;
    public ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra { get; private set; }

    public MovimentacaoParaBaixo(ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra)
    {
        anguloDesejadoDireita  = Quaternion.Euler(0, 0, -contexto.garraDto.Angulos.Abertura);
        anguloDesejadoEsquerda = Quaternion.Euler(0, 0, contexto.garraDto.Angulos.Abertura);

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
        rotacionarPincaFDT(contexto.garraDto.Velocidades.MovAnguloAbertura, anguloDesejadoEsquerda, anguloDesejadoDireita);
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
