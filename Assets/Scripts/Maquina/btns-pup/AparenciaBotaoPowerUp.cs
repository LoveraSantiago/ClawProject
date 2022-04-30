using UnityEngine;

public class AparenciaBotaoPowerUp 
{
    private static readonly int MOSTRANDO_IMAGEM = 1;
    private static readonly int MOSTRANDO_BOTAO  = 2;
    private static readonly int MOSTRANDO_ERROR  = 3;

    private int mostrandoAtual;

    private Sprite spritePupAtual;
    private static SpritesTampaBtnPupDto spritesTampaDto;    
    private BotaoPowerUpDtoV2 botaoDtoV2;

    private Material materialImgPup;

    public AparenciaBotaoPowerUp(BotaoPowerUpDtoV2 botaoDtoV2)
    {
        mostrandoAtual = MOSTRANDO_BOTAO;
        this.botaoDtoV2 = botaoDtoV2;
        this.materialImgPup = botaoDtoV2.SprRendererImgBtn.sharedMaterial;
    }

    public void mostrarBordaSerrilhada()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaSerrilhada;
    }

    public void mostrarBordaNormal()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal;
    }

    public void colorirBotaoFromLevelV2(string corBase, string corTampa)
    {   
        botaoDtoV2.SprRendererBtnBase.color = Utils.getCorByHex(corBase);
        botaoDtoV2.SprRendererBtnTampa.color = Utils.getCorByHex(corTampa);
    }

    public void pressionarBotao()
    {    
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaPressionada;
        botaoDtoV2.SprRendererImgBtn.transform.localPosition -= new Vector3(0, 0.02f, 0);
    }   

    public void despressionarBotao()
    {   
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal; 
        botaoDtoV2.SprRendererImgBtn.transform.localPosition += new Vector3(0, 0.02f, 0);
    }

    public void receberImg(Sprite img)
    {
        spritePupAtual = img;
        botaoDtoV2.SprRendererImgBtn.sprite = img;        
        updateMaterial(1, img);
    }
    
    public void limparImg()
    {
        botaoDtoV2.SprRendererImgBtn.sprite = null;
        updateMaterial(null);        
    }

    public void mostrarSoImagem()
    {
        if(mostrandoAtual != MOSTRANDO_IMAGEM)
        {
            updateBotao(false, spritePupAtual, Color.white, new Vector3(1.25f, 1.25f, 1.25f));                              
            updateMaterial(0, spritePupAtual);                             

            mostrandoAtual = MOSTRANDO_IMAGEM;
        }
    }

    public void mostrarBotao()
    {
        if(mostrandoAtual != MOSTRANDO_BOTAO)
        {
            updateBotao(true, spritePupAtual, Color.white, new Vector3(0.6f, 0.6f, 0.6f)); //TAMANHO ORIGINAL DEIXAR ASSIM?
            updateMaterial(1, spritePupAtual);
            mostrandoAtual = MOSTRANDO_BOTAO;
        }
    }

    public void mostrarErro()
    {
        if(mostrandoAtual != MOSTRANDO_ERROR)
        {
            updateBotao(false, spritesTampaDto.TampaErro, Color.yellow, new Vector3(1.25f, 1.25f, 1.25f));
            updateMaterial(0, spritesTampaDto.TampaErro);
            mostrandoAtual = MOSTRANDO_ERROR;
        }
    }

    private void updateBotao(bool enabled, Sprite img, Color cor, Vector3 posAcrescimo)
    {
        botaoDtoV2.SprRendererBtnTampa.enabled = enabled;
        botaoDtoV2.SprRendererImgBtn.color     = cor;
        botaoDtoV2.SprRendererImgBtn.sprite    = img;
        botaoDtoV2.TransformImgBtn.localScale  = posAcrescimo;
    }

    private void updateMaterial(int estado, Sprite img)
    {
        updateMaterial(img);
        materialImgPup.SetInt("_ligado", estado);
    }

    private void updateMaterial(Sprite img)
    {
        materialImgPup.SetTexture("_MaintText", img.texture);
    }

    public bool isMostrandoImagem()
    {
        return mostrandoAtual == MOSTRANDO_IMAGEM;
    }      

    public static void configurarSpritesTampaBotao(SpritesTampaBtnPupDto spritesTampaDtoArg)
    {
        spritesTampaDto = spritesTampaDtoArg;                        
    }
}
