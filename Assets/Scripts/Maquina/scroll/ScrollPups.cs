using UnityEngine;

public class ScrollPups 
{
    private Sprite[] pupsSprites;
    private Vector2 posicaoInicialDrag;
    private ScrollPupsDto scrollPupsDto;    

    private ItemScrollPup itemPrimeiro;
    private ItemScrollPup itemUltimo;

    public ScrollPups(ScrollPupsDto scrollPupsDto)
    {
        this.scrollPupsDto = scrollPupsDto;
    }

    public void iniciar()
    {
        pupsSprites = PowerUpHelper.getAllSpritesPowerUp();
        for(int contador = 0; contador < scrollPupsDto.ItensBarraRolagem.Length; contador++)
        {
            scrollPupsDto.ItensBarraRolagem[contador].sprite = pupsSprites[contador];
        }
        itemPrimeiro = new ItemScrollPup();
        itemPrimeiro.addItemInfo(0, scrollPupsDto.ItensBarraRolagem[0]);

        itemUltimo = new ItemScrollPup();

        int indiceUltimoItem = scrollPupsDto.ItensBarraRolagem.Length - 1;
        itemUltimo.addItemInfo(indiceUltimoItem, scrollPupsDto.ItensBarraRolagem[indiceUltimoItem]);
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
        updateItens(delta);
    }

    private Vector2 movimentarBarraDeRollagem(Vector2 posToque)
    {
        Vector2 delta = posToque - posicaoInicialDrag;
        posicaoInicialDrag = posToque;

        if(delta.x > 0)
        {
            if (podeRolarParaDireita())
            {
                PosicaoTransform posicao = new PosicaoTransform(scrollPupsDto.TransfBarraRolagem);
                posicao.adicionarNaPosicaoHorizontal(delta);
            }
        }
        else
        {
            PosicaoTransform posicao = new PosicaoTransform(scrollPupsDto.TransfBarraRolagem);
            posicao.adicionarNaPosicaoHorizontal(delta);
        }


        Debug.Log(delta.x > 0 ? "POS" : "NEG");
        return delta;
    }

    private void updateItens(Vector2 delta)
    {
        if(delta.x > 0)
        {
            
        }
        else
        {
            
        }
    }

    private bool podeRolarParaDireita()
    {
        if(itemPrimeiro.indice == 0)
        {
            float posX = itemPrimeiro.getPosEsquerda();
            return scrollPupsDto.SprRendererPlacaExterna.transform.position.x < posX;
        }
        {
            return true;
        }
    }

    private void rolandoParaEsquerda()
    {

    }
}
