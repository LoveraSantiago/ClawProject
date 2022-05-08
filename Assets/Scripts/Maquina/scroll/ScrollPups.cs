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
        for(int contador = 0; contador < scrollPupsDto.ItensScrollPup.Length; contador++)
        {
            scrollPupsDto.ItensScrollPup[contador].SprRendererImgPup.sprite = pupsSprites[contador];
        }

        int indiceZero = 0;
        itemPrimeiro = new ItemScrollPup();       
        itemPrimeiro.addItemInfo(indiceZero, scrollPupsDto.ItensScrollPup[indiceZero]);

        itemUltimo = new ItemScrollPup();
        int indiceUltimoItem = scrollPupsDto.ItensScrollPup.Length - 1;
        itemUltimo.addItemInfo(indiceUltimoItem, scrollPupsDto.ItensScrollPup[indiceUltimoItem]);
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

                if (isPrimeiroElementoDentroArea())
                {
                    updateLadoEsquerdo();
                }
            }
        }
        else
        {
            if (podeRolarParaEsquerda())
            {
                PosicaoTransform posicao = new PosicaoTransform(scrollPupsDto.TransfBarraRolagem);
                posicao.adicionarNaPosicaoHorizontal(delta);

                if (isUltimoElementoDentroArea())
                {
                    updateLadoDireito();                
                }
            }
        }
    }

    private bool podeRolarParaDireita()
    {
        //Debug.Log("podeRolarParaDireita");
        if(itemPrimeiro.indice == 0)
        {
            float posX = itemPrimeiro.getPosEsquerda();
            return scrollPupsDto.SprRendererPlacaInterna.bounds.min.x > posX;
        }        
       return true;        
    } 
    
    private bool podeRolarParaEsquerda()
    {
        //Debug.Log("podeRolarParaEsquerda");
        if (itemUltimo.indice == (pupsSprites.Length - 1))
        {
            float poxX = itemUltimo.getPosDireita();
            return scrollPupsDto.SprRendererPlacaInterna.bounds.max.x < poxX; ;
        }
        return true;
    }

    private bool isPrimeiroElementoDentroArea()
    {
        float xPrimeiroItem = itemPrimeiro.getPosEsquerda();
        float xPlacaInterna = scrollPupsDto.SprRendererPlacaInterna.bounds.min.x;
        return xPrimeiroItem > xPlacaInterna;
    }

    private bool isUltimoElementoDentroArea()
    {
        float xUltimoItem = itemUltimo.getPosDireita();
        float xPlacaInterna = scrollPupsDto.SprRendererPlacaInterna.bounds.max.x;
        //Debug.Log("item " + xUltimoItem + " placa " + xPlacaExterna + " r " + (xUltimoItem < xPlacaExterna));
        return xUltimoItem < xPlacaInterna;            
    }

    private void updateLadoEsquerdo()
    {
        int novoIndicePrimeiro = itemPrimeiro.indice - 1;
        //Debug.Log("<<< Indice Primeiro " + novoIndicePrimeiro);
        if (novoIndicePrimeiro >= 0)
        {
            float novaPosPrimeiro = itemPrimeiro.getPosicaoDeslocadaAEsquerda();
            itemUltimo.addItemInfo(novaPosPrimeiro, pupsSprites[novoIndicePrimeiro]);
            itemPrimeiro.addItemInfo(novoIndicePrimeiro, itemUltimo.itemScrollDto);

            int novoIndiceUltimo = itemUltimo.indice - 1;
            //Debug.Log("<<< Indice Update Ultimo " + novoIndiceUltimo);
            int indiceItem = novoIndiceUltimo % scrollPupsDto.ItensScrollPup.Length;
            itemUltimo.addItemInfo(novoIndiceUltimo, scrollPupsDto.ItensScrollPup[indiceItem]);
        }
    }

    private void updateLadoDireito()
    {
        int novoIndiceUltimo = itemUltimo.indice + 1;
        if(novoIndiceUltimo < pupsSprites.Length)
        {
            float novaPosXUltimo = itemUltimo.getPosicaoDeslocadaADireita();
            //Debug.Log(">>> Indice Ultimo " + novoIndiceUltimo);
            itemPrimeiro.addItemInfo(novaPosXUltimo, pupsSprites[novoIndiceUltimo]);
            itemUltimo.addItemInfo(novoIndiceUltimo, itemPrimeiro.itemScrollDto);

            int novoIndicePrimeiro = itemPrimeiro.indice + 1;
            //Debug.Log(">>> Indice Update Primeiro " + novoIndicePrimeiro);
            int indiceItem = novoIndicePrimeiro % scrollPupsDto.ItensScrollPup.Length;
            itemPrimeiro.addItemInfo(novoIndicePrimeiro, scrollPupsDto.ItensScrollPup[indiceItem]);
        }
    }
}
