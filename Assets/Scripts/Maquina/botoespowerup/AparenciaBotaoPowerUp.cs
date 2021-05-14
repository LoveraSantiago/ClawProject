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
    private SpriteRenderer spriteRendererDentro;
    private SpriteRenderer spriteRendererBorda;
    private SpriteRenderer spriteRendererImg;

    private GameObject goBotaoInterno;
    private GameObject goImagem;
    private GameObject goExclamacao;

    public AparenciaBotaoPowerUp(GameObject goBotaoInterno)
    {
        this.goBotaoInterno = goBotaoInterno;
        mostrandoAtual = MOSTRANDO_BOTAO;
        spriteRendererDentro = goBotaoInterno.GetComponent<SpriteRenderer>();

        Transform contorno = goBotaoInterno.transform.Find("contorno");
        spriteRendererBorda = contorno.GetComponent<SpriteRenderer>();

        goImagem = goBotaoInterno.transform.Find("img-btn").gameObject;
        spriteRendererImg = goImagem.GetComponent<SpriteRenderer>();

        goExclamacao = goBotaoInterno.transform.Find("img-exclamation").gameObject;

        corOriginal = spriteRendererDentro.color;
    }

    public void mostrarBordaSerrilhada()
    {
        spriteRendererBorda.sprite = spriteBordaSerrilhada;
    }

    public void mostrarBordaNormal()
    {
        spriteRendererBorda.sprite = spriteBordaNormal;
    }

    public void colorirBotao()
    {
        spriteRendererDentro.color = Color.black;
    }

    public void voltarCorOriginalBotao()
    {
        spriteRendererDentro.color = corOriginal;
    }

    public void receberImg(Sprite img)
    {
        spriteRendererImg.sprite = img;
    }

    public void limparImg()
    {
        spriteRendererImg.sprite = null;
    }

    public void mostrarSoImagem()
    {
        if(mostrandoAtual != MOSTRANDO_IMAGEM)
        {
            spriteRendererDentro.enabled = false;
            spriteRendererBorda.enabled = false;
            goImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            goExclamacao.SetActive(false);

            mostrandoAtual = MOSTRANDO_IMAGEM;
        }
    }

    public void mostrarBotao()
    {
        if(mostrandoAtual != MOSTRANDO_BOTAO)
        {
            spriteRendererDentro.enabled = true;
            spriteRendererBorda.enabled = true;
            goImagem.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            goExclamacao.SetActive(false);

            mostrandoAtual = MOSTRANDO_BOTAO;
        }
    }

    public void mostrarErro()
    {
        if(mostrandoAtual != MOSTRANDO_ERROR)
        {
            spriteRendererDentro.enabled = false;
            spriteRendererBorda.enabled = false;
            goImagem.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            goExclamacao.SetActive(true);

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
           goBotaoInterno.transform.position.x + posAdicionar.x,
           goBotaoInterno.transform.position.y + posAdicionar.y,
           goBotaoInterno.transform.position.z + posAdicionar.z);

        goBotaoInterno.transform.position = posicaoCalculada;
        return posicaoCalculada;
    }

    public Vector3 getPosicao()
    {
        return goBotaoInterno.transform.position;
    }

    public void moveTowards(Vector3 posicaoDestino, float velocidade)
    {
        goBotaoInterno.transform.position = Vector3.MoveTowards(goBotaoInterno.transform.position, posicaoDestino, velocidade);
    }

    public void colocarNaPosicao(Vector3 posicao)
    {
        goBotaoInterno.transform.position = posicao;
    }

    public static void configurarSpriteBordas(Sprite[] spritesBordas)
    {
        spriteBordaNormal = spritesBordas[0];
        spriteBordaSerrilhada = spritesBordas[1];
    }
}
