using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : GerenciadorDeMovimentacao,
                                               ComunicadorComGerMovNormal
{
    private MovimentacaoDaGarra           movAtual;
    private MovimentacaoParaBaixo         movPBaixo;
    private MovimentacaoDaGarra           movAgarrandoBaixo;
    private MovimentacaoParaCima          movPCima;
    private MovimentacaoDaGarra           movLateral;
    private MovimentacaoAgarrandoEmcima   movAgarrandoCima;

    public GerenciadorDeMovimentacaoNormal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {        
        MovimentacaoDaGarraNormal.configurarComunicadorComGerMovimentacao(this);

        movLateral        = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movPCima          = new MovimentacaoParaCima();
        movPBaixo         = new MovimentacaoParaBaixo();
        movAgarrandoBaixo = new MovimentacaoAgarrandoEmbaixo();
        movAgarrandoCima  = new MovimentacaoAgarrandoEmcima();
    }

    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO INICIO
    public void iniciarMovimentacoes()
    {
        trocarMovimentador(movLateral);
    }

    public void update()
    {
        movAtual.update();
        //Debug.Log(movimentacaoAtual);
    }

    public void fixedUpdate()
    {
        movAtual.fixedUpdate();
    }
    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO FIM

    public void garraColidiuCom(Collider2D other)
    {
        movAtual.garraColidiuCom(other.gameObject);
    }

    private MovimentacaoDaGarra selecionarMecanicaHorizontal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
    {
        switch (mecanicaGarraEscolhida)
        {
            case (GarraManager.MECANICA_GARRA.ZIG_ZAG):
                return new MovimentacaoLateralZigZag();

            case (GarraManager.MECANICA_GARRA.TELEGUIADA):
                return new MovimentacaoLateralTeleguiada();

            case (GarraManager.MECANICA_GARRA.ZIG_ZAGTELEGUIADO):
                return new MovimentacaoLateralZigTeleguiado();

        }
        return new MovimentacaoLateralZigZag();
    }

    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL INICIO    
    public void trocarParaAcaoDescendo()
    {
        AudioController.current.PlayAudioGarra();        
        trocarMovimentador(movPBaixo);
    }

    public void trocarParaAcaoSubindo()
    {        
        trocarMovimentador(movPCima);
    }

    public void trocarParaAcaoNormal()
    {
        AudioController.current.StopAudioGarra();
        trocarMovimentador(movLateral);
    }

    public void trocarParaAcaoAgarrada()
    {
        trocarMovimentador(movAgarrandoBaixo);
    }

    public void trocarParaAcaoSegurando(GarraInteracaoComPowerUp garraInteracaoPowerUp, float tempoDuracao)
    {
        movAgarrandoCima.receberGarraInteracaoComPowerUp(garraInteracaoPowerUp, tempoDuracao);
        trocarMovimentador(movAgarrandoCima);
    }
    //IMPLEMENTACAO INTERFACE COMUNICADORCOMGERMOVNORMAL FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }
    
    public ProdutorDeEvento<string> getProdutorDeEventoTocadoPelaGarra()
    {
        return movPBaixo.produtorEventoGarraAcertou;
    }

    public ProdutorDeEvento<int> getProdutorDeEventoSubidaDaGarra()
    {
        return movPCima.produtorDeEventoSubidaDaGarra;
    }    
}
