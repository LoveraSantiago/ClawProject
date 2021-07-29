public class BoardMontadorNormal : BoardMontador
{
    public void configuradoPeloLevel(AbstractLevel level)
    {        
        arrayDeColetaveis = level.getArrayDeColetaveis();
    }

    public void create(BoardDto boardDto, PoolDeColetaveis poolDeColetaveis)
    {   
        for (int contadorLinha = 0; contadorLinha < boardDto.PosicoesEixoY.Length; contadorLinha++)
        {
            float[] eixoX = getEixoX(boardDto, contadorLinha);
            float alturaY = boardDto.PosicoesEixoY[contadorLinha];
            montarLinha(eixoX, contadorLinha, alturaY, poolDeColetaveis);            
        }     
    }   
}
