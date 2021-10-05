using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }
    private int indice;
    
    private AparenciaBotaoPowerUp aparencia;
    public GlowBotaoPowerUp glow { get; private set; }

    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(int indice, BotaoPowerUpDto botaoDto)
    {
        isDraggavel = false;
        this.indice = indice;

        aparencia = new AparenciaBotaoPowerUp(botaoDto);
        acaoDrag  = new AcaoDragPowerUp(botaoDto);
        glow   = new GlowBotaoPowerUp(botaoDto.SprEfeito);
    }

    public void clicar(
        ControleAcionamentoPowerUp controlePup, 
        ProdutorDeEvento<int> produtorEventoEscolhaPup)
    {
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            aparencia.colorirBotao();
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;
            acaoBtnPowerUp.acionar(indice);
        }
        else
        {
            //Debug.Log("Btn clicado sem pup");
            glow.ligarGlow();
            Time.timeScale = 0;
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
        Time.timeScale = 1;
        controlePup.habilitarPowerUp();
        glow.desligarGlow();
        mudarParaMaterialArcoIris();
        if(evento.hasEntidade)
        {
            PowerUpEntidade pupEntidade = evento.powerUpEntidade;
            receberAcaoPowerUp(new PowerUpParaMaquina(pupEntidade));
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

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {        
        acaoDrag.prepararDraggagem(posInicialDrag, aparencia);
    }

    public void updateDrag(Vector2 posicaoDrag)
    {
        acaoDrag.updateDrag(posicaoDrag, aparencia);
    }

    public bool isDragFinalizadoAtivouPowerUp()
    {
        return acaoDrag.dragFinalizado(indice, acaoBtnPowerUp, aparencia);        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(BotoesPowerUpDto btnsPowerUpsDto)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(btnsPowerUpsDto.BordasBtns);
        AcaoDragPowerUp.configurarAreaDraggavel(btnsPowerUpsDto.AreaDraggavel);        
    }
}
