public class ContadorManager 
{
    private AbstractContadorDeColetaveis contador;
    private ColetaveisDto coletaveisDto;

    public ContadorManager(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if (level.isOrdemLevel())
        {
            contador = new ContadorDeColetaveisOrdenado(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto, coletaveisDto.EfeitoOutline);
        }
        else
        {
            contador = new ContadorDeColetaveis(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto);
        }
    }

    public void iniciar(int totalColetaveis)
    {
        contador.iniciar(totalColetaveis);
    }

    public int contarColetado(ColetavelTile coletavelTile)
    {
        return contador.contarColetado(coletavelTile);
    }

    public void adicionarColetaveisExtras(int qtd)
    {
        contador.adicionarColetaveisExtras(qtd);
    }

    public bool getResultCombinacao()
    {
        return contador.getResultCombinacao();
    }

    public int getIndiceOrdem()
    {
        return contador.getIndiceOrdem();
    }

    public bool isFinished()
    {
        return contador.isFinished();
    }

    public virtual bool isErroOrdem()
    {
        return contador.isErroOrdem();
    }
}
