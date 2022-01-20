using UnityEngine;

public class RemontadorBoard
{
    private ListaDeSprites listaDeSprites;
    private ReferenciasDoBoard referencias;

    public RemontadorBoard(
        ReferenciasDoBoard referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarColetaveis(int[,] arrayDeColetaveis)
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        for (int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
        {   
            int totalColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < totalColunas; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade  = helperColetavel.getColetavelEntidadeById(id);

                if (coletavelEntidade.isVazio())
                {
                    continue;
                }
                else if (coletavelEntidade.isRandom())
                {
                    referencias.updateElementoGo(contadorLinha, contadorColuna, listaDeSprites.getSpriteRandom());                                        
                }
                else
                {
                    string nomeSprite = coletavelEntidade.nomeSprite;
                    Sprite spr = listaDeSprites.getSpriteByName(nomeSprite);
                    referencias.updateElementoGo(contadorLinha, contadorColuna, spr);                    
                }
            }
        }
    }
}
