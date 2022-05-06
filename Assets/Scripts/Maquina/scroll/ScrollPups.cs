using UnityEngine;

public class ScrollPups 
{
    private Vector2 posicaoInicialDrag;
    private Sprite[] pupsSprites;

    private ScrollPupsDto scrollPupsDto;
    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollPups(ScrollPupsDto scrollPupsDto)
    {
        this.scrollPupsDto = scrollPupsDto;
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
    }

    public void iniciar()
    {
        pupsSprites = PowerUpHelper.getAllSpritesPowerUp();
        for(int contador = 1; contador < scrollPupsDto.ItensBarraRolagem.Length - 1; contador++)
        {
            scrollPupsDto.ItensBarraRolagem[contador].sprite = pupsSprites[contador - 1];
        }
    }

    public bool isToqueDentroPlacaInterna(Vector2 posToque)
    {
        return scrollPupsDto.SprRendererPlacaInterna.bounds.Contains(posToque);
    }

    public void prepararBarraDeRolagem(Vector3 posicao)
    {
        posicaoInicialDrag = posicao;
    }

    public void dragBarraDeRolagem(Vector2 posToque)
    {
        Vector2 delta = movimentarBarraDeRollagem(posToque);
    }

    private Vector2 movimentarBarraDeRollagem(Vector2 posToque)
    {
        Vector2 delta = posToque - posicaoInicialDrag;
        posicaoInicialDrag = posToque;
        PosicaoTransform posicao = new PosicaoTransform(scrollPupsDto.TransfBarraRolagem);
        posicao.adicionarNaPosicaoHorizontal(delta);

        Debug.Log(delta.x > 0 ? "POS" : "NEG");
        return delta;
    }
}
