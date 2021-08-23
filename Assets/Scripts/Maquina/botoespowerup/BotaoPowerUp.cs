using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private static MaterialGlow materialGlowGeral;
    private static MaterialGlow materialGlowIndividual;

    private bool isDraggavel;
    public bool hasPowerUp { get; private set; }

    private GlowEfeito glowEfeito;
    private AparenciaBotaoPowerUp aparencia;
    private AcaoDragPowerUp acaoDrag;
    private AcaoBotaoPowerUp acaoBtnPowerUp;

    public BotaoPowerUp(BotaoPowerUpDto botaoDto)
    {
        aparencia = new AparenciaBotaoPowerUp(botaoDto);
        acaoDrag  = new AcaoDragPowerUp(botaoDto);

        isDraggavel = false;
        glowEfeito = new GlowEfeito(botaoDto.SprEfeito.gameObject, materialGlowGeral);
    }

    public void clicar(ControleAcionamentoPowerUp controlePup)
    {
        aparencia.colorirBotao();
        if (hasPowerUp)
        {
            acaoBtnPowerUp.acionar();
            controlePup.notificarAcionado(acaoBtnPowerUp);
            glowEfeito.mudarMaterial(materialGlowIndividual);
            hasPowerUp = false;
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
        glowEfeito.mudarMaterial(materialGlowGeral);
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
               && hasPowerUp
               && controleAcionamento.podeAcionarPupBtn(acaoBtnPowerUp)
               && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragValido(Vector2 posicao)
    {
        return isDraggavel && hasPowerUp && acaoDrag.isPosicaoDentroAreaBotao(posicao);
    }

    public void ligarGlowSucesso()
    {
        glowEfeito.ligarGlowSucesso();
    }

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }

    public void passarCorDoMaterial(Color cor)
    {
        if(glowEfeito.materialGlow == materialGlowIndividual)
        {
            glowEfeito.materialGlow.setCorNoMaterial(Color.yellow);
        }
        else{
            glowEfeito.materialGlow.setCorNoMaterial(cor);
        }
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
        materialGlowGeral = materialIndividualArg;
        materialGlowIndividual = materialIndividualArg;
    }
}
