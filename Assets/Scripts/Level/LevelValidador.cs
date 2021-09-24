using UnityEngine;

public class LevelValidador 
{
    public void validar(AbstractLevel level)
    {
        validarArrayDeColetaveis(level);
    }

    private void validarArrayDeColetaveis(AbstractLevel level)
    {
        if (level.isNormalLevel())
        {
            int[,] arrayDeColetaveis = level.getArrayDeColetaveis();
            for(int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
            {
                for(int contadorColuna = 0; contadorColuna < arrayDeColetaveis.GetLength(1); contadorColuna++)
                {
                    if(contadorLinha % 2 != 0 && 
                       contadorColuna == 6 && 
                       arrayDeColetaveis[contadorLinha, contadorColuna] != 0)
                    {
                        Debug.LogError(level.getLevelName() + " configurado incorretamente com coletavel na linha " + contadorLinha + " par com sexto indice diferente de vazio");
                    }
                }
            }
        }
    }
}
