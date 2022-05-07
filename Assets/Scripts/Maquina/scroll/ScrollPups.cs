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
        Debug.Log("podeRolarParaDireita");
        if(itemPrimeiro.indice == 0)
        {
            float posX = itemPrimeiro.getPosEsquerda();
            return scrollPupsDto.SprRendererPlacaInterna.bounds.min.x > posX;
        }
        {
            return true;
        }
    } 
    
    private bool podeRolarParaEsquerda()
    {
        Debug.Log("podeRolarParaEsquerda");
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
        Debug.Log("<<< Indice Primeiro " + novoIndicePrimeiro);
        if (novoIndicePrimeiro >= 0)
        {
            float novaPosPrimeiro = itemPrimeiro.spriteRenderer.transform.position.x - 1;
            SpriteRenderer sprRendererUltimo = itemUltimo.spriteRenderer;
            sprRendererUltimo.sprite = pupsSprites[novoIndicePrimeiro];
            Vector3 novaPos = new Vector3(novaPosPrimeiro, sprRendererUltimo.transform.position.y, sprRendererUltimo.transform.position.z);
            sprRendererUltimo.transform.position = novaPos;
            itemPrimeiro.addItemInfo(novoIndicePrimeiro, sprRendererUltimo);

            int novoIndiceUltimo = itemUltimo.indice - 1;
            Debug.Log("<<< Indice Update Ultimo " + novoIndiceUltimo);
            itemUltimo.addItemInfo(novoIndiceUltimo, scrollPupsDto.ItensBarraRolagem[novoIndiceUltimo % scrollPupsDto.ItensBarraRolagem.Length]);
        }
    }

    private void updateLadoDireito()
    {
        int novoIndiceUltimo = itemUltimo.indice + 1;
        if(novoIndiceUltimo < pupsSprites.Length)
        {
            float novaPosXUltimo = itemUltimo.spriteRenderer.transform.position.x + 1;
            Debug.Log(">>> Indice Ultimo " + novoIndiceUltimo);

            SpriteRenderer sprRendererHum = itemPrimeiro.spriteRenderer;
            sprRendererHum.sprite = pupsSprites[novoIndiceUltimo];
            Vector3 novaPos = new Vector3(novaPosXUltimo, sprRendererHum.transform.position.y, sprRendererHum.transform.position.z);
            sprRendererHum.transform.position = novaPos;
            itemUltimo.addItemInfo(novoIndiceUltimo, sprRendererHum);

            int novoIndicePrimeiro = itemPrimeiro.indice + 1;
            Debug.Log(">>> Indice Update Primeiro " + novoIndicePrimeiro);
            itemPrimeiro.addItemInfo(novoIndicePrimeiro, scrollPupsDto.ItensBarraRolagem[novoIndicePrimeiro % scrollPupsDto.ItensBarraRolagem.Length]);
        }
    }
}
