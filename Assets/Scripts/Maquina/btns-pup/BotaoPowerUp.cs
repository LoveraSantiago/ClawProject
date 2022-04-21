using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private static EfeitoHolograma efeitoHolograma;

    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }
    private int indice;
    
    private AparenciaBotaoPowerUp aparencia;
    public GlowBotaoPowerUp glow { get; private set; }

    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(int indice, BotoesPowerUpDto btnsPowerUpsDto)
    {
        isDraggavel = false;
        this.indice = indice;

        BotaoPowerUpDto botaoDto = getBotaoPowerUpDto(btnsPowerUpsDto);
        BotaoPowerUpDtoV2 botaoDtoV2 = getBotaoPowerUpDtoV2(btnsPowerUpsDto);
        aparencia = new AparenciaBotaoPowerUp(btnsPowerUpsDto.MaterialImgPup, botaoDto, botaoDtoV2);
        acaoDrag  = new AcaoDragPowerUp(botaoDto, botaoDtoV2);
        glow      = new GlowBotaoPowerUp(botaoDto.SprEfeito);
    }

    public void clicar(BotoesPowerUpDto btnsPowerUpsDto, ControleAcionamentoPowerUp controlePup)
    {
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            aparencia.pressionarBotao();
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;

            BotaoPowerUpDto botaoDto = getBotaoPowerUpDto(btnsPowerUpsDto);
            efeitoHolograma.ligar(botaoDto);
            acaoBtnPowerUp.acionar(indice);
        }
        else
        {
            //Debug.Log("Btn clicado sem pup");
            glow.ligarGlow();
            Utils.pausarGame();
            controlePup.desabilitarPowerUp();
            controlePup.escolhendoPupParaIndice(indice);            
        }
    }

    public void draggar(ControleAcionamentoPowerUp controlePup)
    {
        aparencia.pressionarBotao();
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;
        }
    }

    public void desclicar()
    {
        aparencia.despressionarBotao();
        aparencia.limparImg();
        transformarEmBotaoClicavel();
        efeitoHolograma.desligar();
    }

    public void mudarParaMaterialArcoIris()
    {
        glow.mudarParaMaterialArcoIris();
    }

    //public void receberCorLevel(string corBotao, string corDentro, string corContorno)
    //{
    //    aparencia.colorirBotaoFromLevel(corBotao, corDentro, corContorno);
    //}

    public void receberCorLevelV2(string corBase, string corTampa)
    {
        aparencia.colorirBotaoFromLevelV2(corBase, corTampa);
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
            receberAcaoPowerUp(new PowerUpsParaMaquina(pupEntidade));
        }
    }

    public void devolverPowerUp()
    {
        if (hasPowerUp)
        {
            PlayerPrefsPowerUp.adicionarPup(acaoBtnPowerUp.getTipo(), 1);
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

    private BotaoPowerUpDtoV2 getBotaoPowerUpDtoV2(BotoesPowerUpDto btnPowerUpsDto)
    {
        return btnPowerUpsDto.BtnPowerUpV2[indice];
    }

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {        
        acaoDrag.prepararDraggagem(posInicialDrag, aparencia);
    }

    public void updateDrag(Vector2 posicaoDrag, BotoesPowerUpDto botoesPowerUpsDto)
    {
        BotaoPowerUpDto btnDto = getBotaoPowerUpDto(botoesPowerUpsDto);
        acaoDrag.updateDrag(posicaoDrag, aparencia, btnDto);
    }

    public bool isDragFinalizadoAtivouPowerUp(BotoesPowerUpDto botoesPowerUpsDto)
    {
        BotaoPowerUpDto btnDto = getBotaoPowerUpDto(botoesPowerUpsDto);
        return acaoDrag.dragFinalizado(indice, acaoBtnPowerUp, aparencia, btnDto);        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(BotoesPowerUpDto btnsPowerUpsDto)
    {
        AparenciaBotaoPowerUp.configurarSpritesTampaBotao(
            btnsPowerUpsDto.BordasBtns, btnsPowerUpsDto.TampaBtnPup, btnsPowerUpsDto.TampaBtnPupPressionada, btnsPowerUpsDto.TampaBtnPupSerrilhada);
        AcaoDragPowerUp.configurarAreaDraggavel(btnsPowerUpsDto.AreaDraggavel);
        efeitoHolograma = new EfeitoHolograma(btnsPowerUpsDto.EfeitoHolograma);
    }
}
