using UnityEngine;

public class RemontadorBoard
{
    protected ListaDeSprites listaDeSprites;
    protected ReferenciasDoBoard referencias;

    public RemontadorBoard(
        ReferenciasDoBoard referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarColetaveis(int[,] arrayDeColetaveis)
    {
        for (int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
        {   
            int totalColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < totalColunas; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade = null;

                if (ColetavelEntidade.isIndiceVazio(id))
                {
                    continue;
                }
                else if (ColetavelEntidade.isIndiceRandom(id))
                {
                    referencias.updateElementoGo(contadorLinha, contadorColuna, listaDeSprites.getSpriteRandom());                                        
                }
                else
                {
                    coletavelEntidade = HelperColetavelEntidade.getColetavelEntidadeById(id); 
                    string nomeSprite = coletavelEntidade.nomeSprite;                    
                    Sprite spr = listaDeSprites.getSpriteByName(nomeSprite);
                    referencias.updateElementoGo(contadorLinha, contadorColuna, spr);                    
                }
            }
        }
    }
}
