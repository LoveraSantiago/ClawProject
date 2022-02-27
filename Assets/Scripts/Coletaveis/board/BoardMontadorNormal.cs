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
        PosicaoItensDoBoardDto posYItem = boardDto.PosicoesY;
        for (int contadorLinha = 0; contadorLinha < posYItem.Total; contadorLinha++)
        {
            PosicaoItensDoBoardDto posXItem = getPosicaoItem(boardDto, contadorLinha);
            float alturaY = posYItem.Inicio + (posYItem.Acrescimo * contadorLinha);
            montarLinha(posXItem, contadorLinha, alturaY);
        }     
    }

    protected override void onColetavelCriado(Coletavel coletavel)
    {
        destaque.destacar(coletavel);        
    }
}
 