using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }
    
    private AparenciaBotaoPowerUp aparencia;
    public GlowBotaoPowerUp glow { get; private set; }

    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(BotaoPowerUpDto botaoDto)
    {
        aparencia = new AparenciaBotaoPowerUp(botaoDto);
        acaoDrag  = new AcaoDragPowerUp(botaoDto);
        glow   = new GlowBotaoPowerUp(botaoDto.SprEfeito);
        isDraggavel = false;        
    }

    public void clicar(ControleAcionamentoPowerUp controlePup)
    {
        glow.mudarParaMaterialIndividual();
        if (hasPowerUp)
        {
            aparencia.colorirBotao();
            controlePup.notificarAcionado(acaoBtnPowerUp);
            hasPowerUp = false;
            acaoBtnPowerUp.acionar();
        }
        else
        {
            Debug.Log("Btn clicado sem pup");
            glow.ligarGlow();
            Time.timeScale = 0;
        }
    }

    public void draggar(ControleAcionamentoPowerUp controlePup)
    {
        aparencia.colorirBotao();
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
        glow.mudarParaMaterialArcoIris();
    }

    public void receberCorLevel(string corBotao, string corDentro, string corContorno)
    {
        aparencia.colorirBotaoFromLevel(corBotao, corDentro, corContorno);
    }

    public void receberAcaoPowerUp(AcaoBotaoPowerUp acaoBtnPowerUp)
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
        return isDraggavel && hasPowerUp && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }           

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void prepararDraggagem(Vector3 posInicialDrag)
    {        
        acaoDrag.prepararDraggagem(posInicialDrag);
    }

    public void updateDrag(Vector2 posicaoDrag)
    {
        acaoDrag.updateDrag(posicaoDrag, aparencia);
    }

    public bool isDragFinalizadoAtivouPowerUp(MonoBehaviour monoBehaviour)
    {
        return acaoDrag.dragFinalizado(acaoBtnPowerUp, aparencia, monoBehaviour);        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM

    public static void configurar(
        Sprite[] spritesBordas, GameObject areaDraggavel, 
        MaterialGlow materialGlowGeralArg, MaterialGlow materialIndividualArg)
    {
        AparenciaBotaoPowerUp.configurarSpriteBordas(spritesBordas);
        AcaoDragPowerUp.configurarAreaDraggavel(areaDraggavel);

        GlowBotaoPowerUp.configurar(materialGlowGeralArg, materialIndividualArg);
    }
}
