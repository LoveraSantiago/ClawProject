using System.Collections;

public class BoardMontadorVazio : BoardMontador
{
    public override void configuradoPeloLevel(AbstractLevel level){}

    protected override IEnumerator create(BoardDto boardDto)
    {
        yield return null;
    }

    protected override void onColetavelCriado(int posX, int posY, Coletavel coletavel){}
}
