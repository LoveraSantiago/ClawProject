using UnityEngine;

public class AparenciaBotaoPowerUp 
{
    private static Sprite spriteBordaNormal;
    private static Sprite spriteBordaSerrilhada;

    private Color corOriginal;
    private SpriteRenderer spriteRendererDentro;
    private SpriteRenderer spriteRendererBorda;
    private SpriteRenderer spriteRendererImg;

    private GameObject goBotaoInterno;

    public AparenciaBotaoPowerUp(GameObject goBotaoInterno)
    {
        this.goBotaoInterno = goBotaoInterno;
        spriteRendererDentro = goBotaoInterno.GetComponent<SpriteRenderer>();

        Transform contorno = goBotaoInterno.transform.Find("contorno");
        spriteRendererBorda = contorno.GetComponent<SpriteRenderer>();
        spriteRendererImg = contorno.Find("img-btn").GetComponent<SpriteRenderer>();

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
