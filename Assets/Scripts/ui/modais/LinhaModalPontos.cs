public class LinhaModalPontos 
{
    private LinhaModalPontosDto linhasDto;

    public LinhaModalPontos(LinhaModalPontosDto linhasDto)
    {
        this.linhasDto = linhasDto;
    }

    public void desligar()
    {
        linhasDto.GoLinha.SetActive(false);
    }
}
