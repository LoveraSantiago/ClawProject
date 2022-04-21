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
    private Material materialDefault;

    public AparenciaBotaoPowerUp(Material materialImgPup, BotaoPowerUpDtoV2 botaoDtoV2)
    {
        mostrandoAtual = MOSTRANDO_BOTAO;
        this.botaoDtoV2 = botaoDtoV2;

        this.materialImgPup = new Material(materialImgPup);
        materialDefault = botaoDtoV2.SprRendererImgBtn.sharedMaterial;
    }

    public void mostrarBordaSerrilhada()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaSerrilhada;
    }

    public void mostrarBordaNormal()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal;
    }

    public void pressionarBotao()
    {    
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaPressionada;
        botaoDtoV2.SprRendererImgBtn.transform.localPosition -= new Vector3(0.02f, 0.02f, 0);
    }

    public void colorirBotaoFromLevelV2(string corBase, string corTampa)
    {   
        botaoDtoV2.SprRendererBtnBase.color = Utils.getCorByHex(corBase);
        botaoDtoV2.SprRendererBtnTampa.color = Utils.getCorByHex(corTampa);
    }

    public void despressionarBotao()
    {   
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal; 
        botaoDtoV2.SprRendererImgBtn.transform.localPosition += new Vector3(0.02f, 0.02f, 0);
    }

    public void receberImg(Sprite img)
    {
        spritePupAtual = img;
        botaoDtoV2.SprRendererImgBtn.sprite = img;
        materialImgPup.SetTexture("_MaintText", img.texture);
        botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialImgPup;
    }

    public void limparImg()
    {
        botaoDtoV2.SprRendererImgBtn.sprite = null;
        botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialDefault;
    }

    public void mostrarSoImagem()
    {
        if(mostrandoAtual != MOSTRANDO_IMAGEM)
        {   
            botaoDtoV2.SprRendererBtnTampa.enabled = false;
            botaoDtoV2.SprRendererImgBtn.sprite = spritePupAtual;
            botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialDefault;
            botaoDtoV2.SprRendererImgBtn.color = Color.white;
            botaoDtoV2.TransformImgBtn.localScale = new Vector3(1.25f, 1.25f, 1.25f);            

            mostrandoAtual = MOSTRANDO_IMAGEM;
        }
    }

    public void mostrarBotao()
    {
        if(mostrandoAtual != MOSTRANDO_BOTAO)
        {
            botaoDtoV2.SprRendererBtnTampa.enabled = true;
            botaoDtoV2.SprRendererImgBtn.sprite = spritePupAtual;
            botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialImgPup;
            botaoDtoV2.SprRendererImgBtn.color = Color.white;
            botaoDtoV2.TransformImgBtn.localScale = new Vector3(0.6f, 0.6f, 0.6f);//TAMANHO ORIGINAL DEIXAR ASSIM?

            mostrandoAtual = MOSTRANDO_BOTAO;
        }
    }

    public void mostrarErro()
    {
        if(mostrandoAtual != MOSTRANDO_ERROR)
        {
            botaoDtoV2.SprRendererBtnTampa.enabled = false;
            botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialDefault;
            botaoDtoV2.SprRendererImgBtn.sprite = spritesTampaDto.TampaErro;
            botaoDtoV2.SprRendererImgBtn.color = Color.yellow;
            botaoDtoV2.TransformImgBtn.localScale = new Vector3(1.25f, 1.25f, 1.25f);

            mostrandoAtual = MOSTRANDO_ERROR;
        }
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
