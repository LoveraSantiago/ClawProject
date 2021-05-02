using UnityEngine;

public class AparenciaBotaoPowerUp 
{
    private static Sprite spriteBordaNormal;
    private static Sprite spriteBordaSerrilhada;

    private Color corOriginal;
    private SpriteRenderer spriteRendererDentro;
    private SpriteRenderer spriteRendererBorda;
    private SpriteRenderer spriteRendererImg;

    public AparenciaBotaoPowerUp(GameObject goBotaoInterno)
    {
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

    public static void configurarSpriteBordas(Sprite[] spritesBordas)
    {
        spriteBordaNormal = spritesBordas[0];
        spriteBordaSerrilhada = spritesBordas[1];
    }
}
