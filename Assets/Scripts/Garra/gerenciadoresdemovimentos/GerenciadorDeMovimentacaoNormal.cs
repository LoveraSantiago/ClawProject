using UnityEngine;

public class GerenciadorDeMovimentacaoNormal : ComunicadorComGerMovimentacao
{
    private MovimentacaoDaGarra           movimentacaoAtual;
    private MovimentacaoParaBaixo         movPBaixo;
    private MovimentacaoDaGarra           movAgarrandoBaixo;
    private MovimentacaoParaCima          movPCima;
    private MovimentacaoDaGarraHorizontal movLateral;
    private MovimentacaoAgarrandoEmcima   movAgarrandoCima;

    public GerenciadorDeMovimentacaoNormal(GarraDto componentesDaGarraDto, 
        GarraManager.MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacaoGarra(componentesDaGarraDto, this, inputGame);        

        movLateral        = selecionarMecanicaHorizontal(mecanicaGarraEscolhida);
        movPCima          = new MovimentacaoParaCima();
        movPBaixo         = new MovimentacaoParaBaixo();
        movAgarrandoBaixo = new MovimentacaoAgarrandoEmbaixo();
        movAgarrandoCima  = new MovimentacaoAgarrandoEmcima();
    }

    public void iniciarMovimentacoes()
    {
        trocarMovimentador(movLateral);
    }

    public void update()
    {
        movimentacaoAtual.update();
        //Debug.Log(movimentacaoAtual);
    }

    public void fixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();
    }

    public void garraColidiuCom(Collider2D other)
    {
        movimentacaoAtual.garraColidiuCom(other.gameObject);
    }

    private MovimentacaoDaGarraHorizontal selecionarMecanicaHorizontal(GarraManager.MECANICA_GARRA mecanicaGarraEscolhida)
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

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO    
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
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM

    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movimentacaoAtual = movimentador;
    }

    public ProdutorDeEvento<DirecaoDaGarra> getDisparadorDeEventoDeDirecao()
    {
        return MovimentacaoDaGarraHorizontal.produtorEventoDirecao;
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
