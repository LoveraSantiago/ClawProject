using UnityEngine;

public class LevelValidador 
{
    public void validar(AbstractLevel level)
    {
        validarArrayDeColetaveis(level);
        validarArrayDeColetaveisSub(level);
    }

    private void validarArrayDeColetaveis(AbstractLevel level)
    {
        if (level.isNormalLevel() || 
            level.isElevadorLevel())
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
                        Debug.LogError(level.getLevelName() + 
                                       " array coletavel configurado incorretamente com coletavel na linha " 
                                       + contadorLinha + 
                                       " par com sexto indice diferente de vazio");
                    }
                }
            }
        }
    }

    private void validarArrayDeColetaveisSub(AbstractLevel level)
    {
        if (level.isElevadorLevel())
        {
            int[,] arrayDeColetaveis = level.getArrayDeColetaveisSub();
            for (int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < arrayDeColetaveis.GetLength(1); contadorColuna++)
                {
                    if (contadorLinha % 2 == 0 &&
                       contadorColuna == 6 &&
                       arrayDeColetaveis[contadorLinha, contadorColuna] != 0)
                    {
                        Debug.LogError(level.getLevelName() + 
                                       " array sub coletavel configurado incorretamente com coletavel na linha " 
                                       + contadorLinha + 
                                       " impar com sexto indice diferente de vazio");
                    }
                }
            }

            TipoContagemTempoDto contagemTempo = level.getTempoContagem();
            if (!contagemTempo.isContagemContinua())
            {
                Debug.LogError(level.getLevelName() + 
                               " level tipo elevador com tipo de contagem nao continua");
            }

            if (contagemTempo.tempo.Equals(AbstractLevel.TIMER_ZERO))
            {
                Debug.LogError(level.getLevelName() +
                               " level com tempo configurado igual a zero");
            }
        }
    }
}
