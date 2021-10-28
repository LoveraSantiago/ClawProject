using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : GerenciadorDeMovimentacao,
                                               ComunicadorComGerMovNormal,
                                               AcaoInfoDaGarra.ProdutorEvento
{
    private MovimentacaoDaGarra   movAtual;
    private MovimentacaoParaBaixo movPBaixo;
    private MovimentacaoParaCima  movPCima;
    private MovimentacaoDaGarra movLateral;//GUARDA ESTADO DE DIRECAO    
    private MovimentacaoDaGarra   movParado;

    public GerenciadorDeMovimentacaoNormal()
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);

        movLateral        = new MovimentacaoLateralZigZag();        
        movParado         = new MovimentacaoParadoNormal();

        ProdutorDeEvento<InformacoesDaGarraDto> produtorEventoInfoGarra = new ProdutorDeEvento<InformacoesDaGarraDto>();
        movPCima          = new MovimentacaoParaCima(produtorEventoInfoGarra);
        movPBaixo         = new MovimentacaoParaBaixo(produtorEventoInfoGarra);
    }

    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO INICIO
    public override void iniciarMovimentacoes()
    {
        trocarMovimentador(movLateral);
    }

    public override void update(InputGame inputGame)
    {
        movAtual.update(inputGame);
        //Debug.Log(movimentacaoAtual);
    }

    public override void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }

    public override void garraColidiuCom(Collider2D other)
    {
        movAtual.garraColidiuCom(other.gameObject);
    }

    public override void garraComemorar()
    {
        movAtual.playAnimcaoComemorar();
    }
    //IMPLEMENTANDO CLASSE ABSTRATA GERENCIADORDEMOVIMENTACAO FIM

    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL INICIO    
    public void trocarParaAcaoDescendo()
    {
        AudioController.current.PlayAudioGarra();        
        trocarMovimentador(movPBaixo);
    }

    public void trocarParaAcaoSubindo()
    {
        movPCima.toAcaoNormal();
        trocarMovimentador(movPCima);
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        if (movAtual.isPlayAnimacaoComemorando())
        {
            //Debug.Log("comemorando");
            trocarParaAcaoParado();
        }
        else
        {
            //Debug.Log("normal");
            trocarMovimentador(movLateral);
        }
    }

    public void trocarParaAcaoAgarrada()
    {
        trocarMovimentador(new MovimentacaoAgarrandoEmbaixo());
    }

    public void trocarParaAcaoVoltarParaCima()
    {
        movPCima.toAcaoEsperar();
        trocarMovimentador(movPCima);
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(new MovimentacaoVoltarParaMeioNormal());
    }

    public void trocarParaAcaoParado()
    {
        trocarMovimentador(movParado);
    }
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

    ProdutorDeEvento<InformacoesDaGarraDto> AcaoInfoDaGarra.ProdutorEvento.getProdutorDeEvento()
    {        
        return movPBaixo.produtorEventoInfoGarra;
    }

    public override ProdutorDeEvento<DirecaoDaGarra> getProdutorDeEvento()
    {
        return ((AcaoSincroniaComDirecaoDaGarra.ProdutorEvento)movParado).getProdutorDeEvento();
    }
}
