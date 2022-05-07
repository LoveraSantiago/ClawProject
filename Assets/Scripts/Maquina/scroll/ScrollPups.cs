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
        //Debug.DrawLine(Vector3.zero, scrollPupsDto.ItensBarraRolagem[0].bounds.min, Color.red, 1000);
        //Debug.DrawLine(Vector3.zero, scrollPupsDto.ItensBarraRolagem[0].bounds.max, Color.green, 1000);
        //Debug.DrawLine(Vector3.zero, scrollPupsDto.ItensBarraRolagem[0].bounds.max, Color.blue, 1000);
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
        movimentarBarraDeRollagem(posToque);        
    }

    private void movimentarBarraDeRollagem(Vector2 posToque)
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

            if (isUltimoElementoDentroArea())
            {
                updateLastItem();                
            }
        }
    }

    private bool podeRolarParaDireita()
    {
        if(itemPrimeiro.indice == 0)
        {
            float posX = itemPrimeiro.getPosEsquerda();
            return scrollPupsDto.SprRendererPlacaInterna.transform.position.x < posX;
        }
        {
            return true;
        }
    }    

    private bool isUltimoElementoDentroArea()
    {
        float xUltimoItem = itemUltimo.getPosDireita();
        float xPlacaExterna = scrollPupsDto.SprRendererPlacaInterna.bounds.max.x;
        Debug.Log("item " + xUltimoItem + " placa " + xPlacaExterna + " r " + (xUltimoItem < xPlacaExterna));
        return xUltimoItem < xPlacaExterna;            
    }

    private void updateLastItem()
    {
        float novaPosXUltimo = itemUltimo.spriteRenderer.transform.position.x + 1;
        int novoIndiceUltimo = itemUltimo.indice + 1;

        SpriteRenderer sprRendererHum = itemPrimeiro.spriteRenderer;
        sprRendererHum.sprite = pupsSprites[novoIndiceUltimo];
        sprRendererHum.transform.position = new Vector3(novaPosXUltimo, sprRendererHum.transform.position.y, sprRendererHum.transform.position.z);

        itemUltimo.addItemInfo(novoIndiceUltimo, sprRendererHum);

        int novoIndicePrimeiro = (itemPrimeiro.indice + 1) % scrollPupsDto.ItensBarraRolagem.Length;
        itemPrimeiro.addItemInfo(novoIndicePrimeiro, scrollPupsDto.ItensBarraRolagem[novoIndicePrimeiro]);
    }
}
