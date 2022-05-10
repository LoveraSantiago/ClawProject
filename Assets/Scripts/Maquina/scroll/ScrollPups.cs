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

    public void configuradoPeloLevel(Materiais7SegmentosDto mat7Segmentos, AbstractLevel level)
    {
        pupsSprites = PowerUpHelper.getAllSpritesPowerUp();
        configurarItens(mat7Segmentos, level);
    }

    public void iniciar()
    {
        inicializarItens();
    }

    public bool isToqueDentroPlacaInterna(Vector2 posToque)
    {
        return scrollPupsDto.SprRendererPlacaInterna.bounds.Contains(posToque);
    }

    public Sprite getSpritePupTocado(Vector2 posToque)
    {
        for(int contador = 0; contador < scrollPupsDto.ItensScrollPup.Length; contador++)
        {
            ItemScrollDto item = scrollPupsDto.ItensScrollPup[contador];
            if (item.SprRendererDivisoria.bounds.Contains(posToque))
            {
                return item.SprRendererImgPup.sprite;
            }
        }
        return null;
    }

    public void prepararBarraDeRolagem(Vector3 posicao)
    {
        posicaoInicialDrag = posicao;
    }

    public void dragBarraDeRolagem(Vector2 posToque)
    {
        movimentarBarraDeRollagem(posToque);        
    }

    private void configurarItens(Materiais7SegmentosDto mat7Segmentos, AbstractLevel level)
    {
        string hexCor = level.getDicionarioDeCores()[ConstantesCoresMaquinaV2.SCROLL_PUP_DIGITOS];
        Color corDigito = Utils.getCorByHex(hexCor);
        Material material7Segmentos = mat7Segmentos.getMaterialFromAlbedo(level.isLevelAlbedo0DigitosScrollPup());

        for (int contador = 0; contador < scrollPupsDto.ItensScrollPup.Length; contador++)
        {
            configurarItem(contador, material7Segmentos, corDigito);
        }
    }

    private void configurarItem(int contador, Material material7Segmentos, Color corDigito)
    {
        ItemScrollDto itemScrollDto = scrollPupsDto.ItensScrollPup[contador];
        itemScrollDto.SprRendererImgPup.sprite = pupsSprites[contador];

        int qtdPup = PowerUpHelper.getQtdPupsFromIndice(contador);
        itemScrollDto.SprRendererDigito1.color = Color.white;
        itemScrollDto.SprRendererDigito2.color = Color.white;

        itemScrollDto.SprRendererDigito1.sharedMaterial = configMaterialDigito(material7Segmentos, qtdPup / 10, corDigito);
        itemScrollDto.SprRendererDigito2.sharedMaterial = configMaterialDigito(material7Segmentos, qtdPup % 10, corDigito);
    }

    private Material configMaterialDigito(Material material, int digito, Color cor)
    {
        Material7Digitos material7Digitos = new Material7Digitos(material);
        material7Digitos.addCorDesligado(cor);
        material7Digitos.addDigito(digito);
        return material7Digitos.material;
    }

    private void inicializarItens()
    {
        int indiceZero = 0;
        itemPrimeiro = new ItemScrollPup();
        itemPrimeiro.addItemInfo(indiceZero, scrollPupsDto.ItensScrollPup[indiceZero]);

        itemUltimo = new ItemScrollPup();
        int indiceUltimoItem = scrollPupsDto.ItensScrollPup.Length - 1;
        itemUltimo.addItemInfo(indiceUltimoItem, scrollPupsDto.ItensScrollPup[indiceUltimoItem]);
    }

    private void movimentarBarraDeRollagem(Vector2 posToque)
    {
        Vector2 delta = posToque - posicaoInicialDrag;
        posicaoInicialDrag = posToque;

        if(delta.x > 0)
        {
            if (podeRolarParaDireita())
            {
                atualizarPosicaoBarra(delta);
                if (isPrimeiroElementoDentroArea())
                {
                    updateLadoEsquerdo();
                }
            }
        }
        else if(delta.x < 0)
        {
            if (podeRolarParaEsquerda())
            {
                atualizarPosicaoBarra(delta);
                if (isUltimoElementoDentroArea())
                {
                    updateLadoDireito();                
                }
            }
        }
    }

    private void atualizarPosicaoBarra(Vector2 delta)
    {
        PosicaoTransform posicao = new PosicaoTransform(scrollPupsDto.TransfBarraRolagem);
        posicao.adicionarNaPosicaoHorizontal(delta);
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
        if (novoIndicePrimeiro >= 0)
        {
            float novaPosPrimeiro = itemPrimeiro.getPosicaoDeslocadaAEsquerda();
            //Debug.Log("<<< Indice Primeiro " + novoIndicePrimeiro);
            int qtdPups = PowerUpHelper.getQtdPupsFromIndice(novoIndicePrimeiro);
            itemUltimo.updateItemInfo(novaPosPrimeiro, pupsSprites[novoIndicePrimeiro], qtdPups);
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
            int qtdPups = PowerUpHelper.getQtdPupsFromIndice(novoIndiceUltimo);
            itemPrimeiro.updateItemInfo(novaPosXUltimo, pupsSprites[novoIndiceUltimo], qtdPups);
            itemUltimo.addItemInfo(novoIndiceUltimo, itemPrimeiro.itemScrollDto);

            int novoIndicePrimeiro = itemPrimeiro.indice + 1;
            //Debug.Log(">>> Indice Update Primeiro " + novoIndicePrimeiro);
            int indiceItem = novoIndicePrimeiro % scrollPupsDto.ItensScrollPup.Length;
            itemPrimeiro.addItemInfo(novoIndicePrimeiro, scrollPupsDto.ItensScrollPup[indiceItem]);
        }
    }
}
