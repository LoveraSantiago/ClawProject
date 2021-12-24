using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private static EfeitoHolograma efeitoHolograma;

    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }
    private int indice;
    
    private AparenciaBotaoPowerUp aparencia;
    private PosicaoBotaoPowerUp posicao;
    public GlowBotaoPowerUp glow { get; private set; }

    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(int indice, BotoesPowerUpDto btnsPowerUpsDto)
    {
        isDraggavel = false;
        this.indice = indice;

        BotaoPowerUpDto botaoDto = getBotaoPowerUpDto(btnsPowerUpsDto);
        aparencia = new AparenciaBotaoPowerUp(botaoDto);
        posicao   = new PosicaoBotaoPowerUp(botaoDto);
        acaoDrag  = new AcaoDragPowerUp(botaoDto);
        glow      = new GlowBotaoPowerUp(botaoDto.SprEfeito);
    }

    public void clicar(
        BotoesPowerUpDto btnsPowerUpsDto,
        ControleAcionamentoPowerUp controlePup, 
        ProdutorDeEvento<int> produtorEventoEscolhaPup)
    {
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            aparencia.colorirBotao();
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;
            efeitoHolograma.ligar(posicao.getPosicaoParent(), posicao.getRotacaoParent());
            acaoBtnPowerUp.acionar(indice);
        }
        else
        {
            //Debug.Log("Btn clicado sem pup");
            glow.ligarGlow();
            Utils.pausarGame();
            controlePup.desabilitarPowerUp();
            produtorEventoEscolhaPup.produziuEvento(indice);
        }
    }

    public void draggar(ControleAcionamentoPowerUp controlePup)
    {
        aparencia.colorirBotao();
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;
        }
    }

    public void desclicar()
    {
        aparencia.voltarCorOriginalBotao();
        aparencia.limparImg();
        transformarEmBotaoClicavel();
        efeitoHolograma.desligar();
    }

    public void mudarParaMaterialArcoIris()
    {
        glow.mudarParaMaterialArcoIris();
    }

    public void receberCorLevel(string corBotao, string corDentro, string corContorno)
    {
        aparencia.colorirBotaoFromLevel(corBotao, corDentro, corContorno);
    }

    public void receberAcaoPowerUp(PowerUpBtnInfo evento, ControleAcionamentoPowerUp controlePup)
    {
        Utils.continuarGame();
        controlePup.habilitarPowerUp();
        glow.desligarGlow();
        mudarParaMaterialArcoIris();
        if(evento.hasEntidade)
        {
            PowerUpEntidade pupEntidade = evento.powerUpEntidade;
            receberAcaoPowerUp(new PowerUpParaMaquina(pupEntidade));
        }
    }

    public void devolverPowerUp()
    {
        if (hasPowerUp)
        {
            PlayerPrefsPup.adicionarPup(acaoBtnPowerUp.getTipo(), 1);
        }
    }

    private void receberAcaoPowerUp(AcaoBotaoPowerUp acaoBtnPowerUp)
    {
        this.acaoBtnPowerUp = acaoBtnPowerUp;
        if (acaoBtnPowerUp.isClicavel())
        {
            transformarEmBotaoClicavel();
        }
        else
        {
            transformarEmBotaoDragavel();
        }
        aparencia.receberImg(acaoBtnPowerUp.getImgBotao());
        hasPowerUp = true;
    }

    private void transformarEmBotaoDragavel()
    {
        aparencia.mostrarBordaSerrilhada();
        isDraggavel = true;
    }

    private void transformarEmBotaoClicavel()
    {
        aparencia.mostrarBordaNormal();
        isDraggavel = false;
    }       

    public bool isCliqueValido(ControleAcionamentoPowerUp controleAcionamento, Vector2 posicao)
    {
        return !isDraggavel            
               && controleAcionamento.podeAcionarPupBtn(acaoBtnPowerUp)
               && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragValido(Vector2 posicao)
    {
        return isDraggavel 
               && hasPowerUp 
               && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }           

    private BotaoPowerUpDto getBotaoPowerUpDto(BotoesPowerUpDto btnPowerUpsDto)
    {
        return btnPowerUpsDto.BtnPowerUp[indice];
    }

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {        
        acaoDrag.prepararDraggagem(posInicialDrag, aparencia);
    }

    public void updateDrag(Vector2 posicaoDrag)
    {
        acaoDrag.updateDrag(posicaoDrag, posicao, aparencia);
    }

    public bool isDragFinalizadoAtivouPowerUp()
    {
        return acaoDrag.dragFinalizado(indice, acaoBtnPowerUp, posicao, aparencia);        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(BotoesPowerUpDto btnsPowerUpsDto)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(btnsPowerUpsDto.BordasBtns);
        AcaoDragPowerUp.configurarAreaDraggavel(btnsPowerUpsDto.AreaDraggavel);
        efeitoHolograma = new EfeitoHolograma(btnsPowerUpsDto.EfeitoHolograma);
    }
}
