public class BoardMontadorNormal : BoardMontador
{
    private DestaqueGrayScale destaque;

    public override void configuradoPeloLevel(AbstractLevel level)
    {   
        setArrayDeColetavel(level.getArrayDeColetaveis());
        destaque = new DestaqueGrayScale(level);
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
        destaque.destacar(coletavel);        
    }
}
 