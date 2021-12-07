public class BoardMontadorNormal : BoardMontador
{
    public void configuradoPeloLevel(AbstractLevel level)
    {        
        setArrayDeColetavel(level.getArrayDeColetaveis());
    }

    protected override void create(BoardDto boardDto)
    {   
        for (int contadorLinha = 0; contadorLinha < boardDto.PosicoesEixoY.Length; contadorLinha++)
        {
            float[] eixoX = getEixoX(boardDto, contadorLinha);
            float alturaY = boardDto.PosicoesEixoY[contadorLinha];
            montarLinha(eixoX, contadorLinha, alturaY);            
        }     
    }

    protected override void onColetavelCriado(ColetavelTile coletavel)
    {

    }
}
 