using UnityEngine;

public class AparenciaBotaoPowerUp 
{
    private static readonly int MOSTRANDO_IMAGEM = 1;
    private static readonly int MOSTRANDO_BOTAO  = 2;
    private static readonly int MOSTRANDO_ERROR  = 3;

    private int mostrandoAtual;

    //private static Sprite spriteBordaNormal;
    //private static Sprite spriteBordaSerrilhada;

    private static SpritesTampaBtnPupDto spritesTampaDto;        

    private Color corOriginal;    
    private BotaoPowerUpDto btnDto;
    private BotaoPowerUpDtoV2 botaoDtoV2;

    private Material materialImgPup;
    private Material materialDefault;

    public AparenciaBotaoPowerUp(Material materialImgPup, BotaoPowerUpDto botaoDto, BotaoPowerUpDtoV2 botaoDtoV2)
    {
        mostrandoAtual = MOSTRANDO_BOTAO;
        btnDto = botaoDto;
        this.botaoDtoV2 = botaoDtoV2;
        corOriginal = btnDto.SprParteDentro.color;

        this.materialImgPup = new Material(materialImgPup);
        materialDefault = botaoDtoV2.SprRendererImgBtn.sharedMaterial;
    }

    //public void mostrarBordaSerrilhada()
    //{
    //    btnDto.SprContorno.sprite = spriteBordaSerrilhada;
    //}

    public void mostrarBordaSerrilhada()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaSerrilhada;
    }

    //public void mostrarBordaNormal()
    //{
    //    btnDto.SprContorno.sprite = spriteBordaNormal;
    //}

    public void mostrarBordaNormal()
    {
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal;
    }

    //public void colorirBotao()
    //{
    //    btnDto.SprParteDentro.color = Color.black;    //    
    //}

    public void pressionarBotao()
    {    
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaPressionada;
        botaoDtoV2.SprRendererImgBtn.transform.localPosition -= new Vector3(0.02f, 0.02f, 0);
    }

    //public void colorirBotaoFromLevel(string corBotao, string corDentro, string corContorno)
    //{
    //    corOriginal = Utils.getCorByHex(corDentro);
    //    btnDto.SprAreaExterna.color = Utils.getCorByHex(corBotao);
    //    btnDto.SprParteDentro.color = corOriginal;
    //    btnDto.SprContorno.color = Utils.getCorByHex(corContorno);
    //}

    public void colorirBotaoFromLevelV2(string corBase, string corTampa)
    {
        corOriginal = Utils.getCorByHex(corTampa);
        botaoDtoV2.SprRendererBtnBase.color = Utils.getCorByHex(corBase);
        botaoDtoV2.SprRendererBtnTampa.color = Utils.getCorByHex(corTampa);
    }

    //public void voltarCorOriginalBotao()
    //{
    //    btnDto.SprParteDentro.color = corOriginal;
    //}

    public void despressionarBotao()
    {   
        botaoDtoV2.SprRendererBtnTampa.sprite = spritesTampaDto.TampaNormal; 
        botaoDtoV2.SprRendererImgBtn.transform.localPosition += new Vector3(0.02f, 0.02f, 0);
    }

    public void receberImg(Sprite img)
    {
        //btnDto.SprImagem.sprite = img;
        botaoDtoV2.SprRendererImgBtn.sprite = img;
        materialImgPup.SetTexture("_MaintText", img.texture);
        botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialImgPup;
    }

    //public void limparImg()
    //{
    //    btnDto.SprImagem.sprite = null;        
    //}

    public void limparImg()
    {
        botaoDtoV2.SprRendererImgBtn.sprite = null;
        botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialDefault;
    }

    //public void prepararRotacaoImgDrag()
    //{
    //    Transform transformBtnPup = btnDto.GoBtnPowerUp.transform;
    //    btnDto.GoAreaExterna.transform.localRotation = transformBtnPup.localRotation;
    //    transformBtnPup.localRotation = Quaternion.identity;
    //}

    public void prepararRotacaoImgDrag()
    {
        //Transform transformBtnPup = botaoDtoV2.TransformBtnTampa;
        //btnDto.GoAreaExterna.transform.localRotation = transformBtnPup.localRotation;
        //transformBtnPup.localRotation = Quaternion.identity;
    }

    //public void mostrarSoImagem()
    //{
    //    if(mostrandoAtual != MOSTRANDO_IMAGEM)
    //    {
    //        btnDto.SprParteDentro.enabled = false;
    //        btnDto.SprContorno.enabled = false;
    //        btnDto.GoImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //        btnDto.GoExclamacao.SetActive(false);

    //        mostrandoAtual = MOSTRANDO_IMAGEM;
    //    }
    //}

    public void mostrarSoImagem()
    {
        if(mostrandoAtual != MOSTRANDO_IMAGEM)
        {
            botaoDtoV2.SprRendererBtnTampa.enabled = false;
            botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialDefault;
            botaoDtoV2.TransformImgBtn.localScale = new Vector3(1.25f, 1.25f, 1.25f);            

            mostrandoAtual = MOSTRANDO_IMAGEM;
        }
    }

    //public void mostrarBotao()
    //{
    //    if(mostrandoAtual != MOSTRANDO_BOTAO)
    //    {
    //        btnDto.SprParteDentro.enabled = true;
    //        btnDto.SprContorno.enabled = true;
    //        btnDto.GoImagem.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    //        btnDto.GoExclamacao.SetActive(false);

    //        mostrandoAtual = MOSTRANDO_BOTAO;
    //    }
    //}

    public void mostrarBotao()
    {
        if(mostrandoAtual != MOSTRANDO_BOTAO)
        {
            botaoDtoV2.SprRendererBtnTampa.enabled = true;
            botaoDtoV2.SprRendererImgBtn.sharedMaterial = materialImgPup;
            botaoDtoV2.TransformImgBtn.localScale = new Vector3(0.6f, 0.6f, 0.6f);//TAMANHO ORIGINAL DEIXAR ASSIM?

            mostrandoAtual = MOSTRANDO_BOTAO;
        }
    }

    //public void mostrarErro()
    //{
    //    if(mostrandoAtual != MOSTRANDO_ERROR)
    //    {
    //        btnDto.SprParteDentro.enabled = false;
    //        btnDto.SprContorno.enabled = false;
    //        btnDto.GoImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //        btnDto.GoExclamacao.SetActive(true);

    //        mostrandoAtual = MOSTRANDO_ERROR;
    //    }
    //}

    public void mostrarErro()
    {
        if(mostrandoAtual != MOSTRANDO_ERROR)
        {
            btnDto.SprParteDentro.enabled = false;
            btnDto.SprContorno.enabled = false;
            btnDto.GoImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            btnDto.GoExclamacao.SetActive(true);

            mostrandoAtual = MOSTRANDO_ERROR;
        }
    }

    public bool isMostrandoImagem()
    {
        return mostrandoAtual == MOSTRANDO_IMAGEM;
    }      

    public static void configurarSpritesTampaBotao(SpritesTampaBtnPupDto spritesTampaDtoArg)
    {
        //spriteBordaNormal = spritesBordas[0];
        //spriteBordaSerrilhada = spritesBordas[1];

        //TRANSFORMAR EM UM UNICO DTO
        spritesTampaDto = spritesTampaDtoArg;                        
    }
}
