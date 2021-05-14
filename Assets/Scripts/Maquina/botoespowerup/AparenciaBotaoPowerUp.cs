using UnityEngine;

public class AparenciaBotaoPowerUp 
{
    private static readonly int MOSTRANDO_IMAGEM = 1;
    private static readonly int MOSTRANDO_BOTAO  = 2;
    private static readonly int MOSTRANDO_ERROR  = 3;

    private int mostrandoAtual;

    private static Sprite spriteBordaNormal;
    private static Sprite spriteBordaSerrilhada;

    private Color corOriginal;    
    private BotaoPowerUpDto btnDto;

    public AparenciaBotaoPowerUp(BotaoPowerUpDto botaoDto)
    {
        mostrandoAtual = MOSTRANDO_BOTAO;
        this.btnDto = botaoDto;                                         
        corOriginal = btnDto.SprParteDentro.color;
    }

    public void mostrarBordaSerrilhada()
    {
        btnDto.SprContorno.sprite = spriteBordaSerrilhada;
    }

    public void mostrarBordaNormal()
    {
        btnDto.SprContorno.sprite = spriteBordaNormal;
    }

    public void colorirBotao()
    {
        btnDto.SprParteDentro.color = Color.black;
    }

    public void voltarCorOriginalBotao()
    {
        btnDto.SprParteDentro.color = corOriginal;
    }

    public void receberImg(Sprite img)
    {
        btnDto.SprImagem.sprite = img;
    }

    public void limparImg()
    {
        btnDto.SprImagem.sprite = null;
    }

    public void mostrarSoImagem()
    {
        if(mostrandoAtual != MOSTRANDO_IMAGEM)
        {
            btnDto.SprParteDentro.enabled = false;
            btnDto.SprContorno.enabled = false;
            btnDto.GoImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            btnDto.GoExclamacao.SetActive(false);

            mostrandoAtual = MOSTRANDO_IMAGEM;
        }
    }

    public void mostrarBotao()
    {
        if(mostrandoAtual != MOSTRANDO_BOTAO)
        {
            btnDto.SprParteDentro.enabled = true;
            btnDto.SprContorno.enabled = true;
            btnDto.GoImagem.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            btnDto.GoExclamacao.SetActive(false);

            mostrandoAtual = MOSTRANDO_BOTAO;
        }
    }

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

    public Vector3 adicionarNaPosicao(Vector3 posAdicionar)
    {
        Vector3 posicaoCalculada = new Vector3(
           btnDto.GoParteDentro.transform.position.x + posAdicionar.x,
           btnDto.GoParteDentro.transform.position.y + posAdicionar.y,
           btnDto.GoParteDentro.transform.position.z + posAdicionar.z);

        btnDto.GoParteDentro.transform.position = posicaoCalculada;
        return posicaoCalculada;
    }

    public Vector3 getPosicao()
    {
        return btnDto.GoParteDentro.transform.position;
    }

    public void moveTowards(Vector3 posicaoDestino, float velocidade)
    {
        btnDto.GoParteDentro.transform.position = Vector3.MoveTowards(
            btnDto.GoParteDentro.transform.position, posicaoDestino, velocidade);
    }

    public void colocarNaPosicao(Vector3 posicao)
    {
        btnDto.GoParteDentro.transform.position = posicao;
    }

    public static void configurarSpriteBordas(Sprite[] spritesBordas)
    {
        spriteBordaNormal = spritesBordas[0];
        spriteBordaSerrilhada = spritesBordas[1];
    }
}
