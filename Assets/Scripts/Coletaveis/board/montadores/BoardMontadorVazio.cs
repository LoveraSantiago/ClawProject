using System.Collections;

public class BoardMontadorVazio : BoardMontador
{
    public override void configuradoPeloLevel(AbstractLevel level){}

    protected override IEnumerator create(BoardDto boardDto)
    {
        yield return null;
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        yield return null;
    }
}
