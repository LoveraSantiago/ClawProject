public class ComponenteGarraDtoDaGarra 
{
    protected GarraDto garraDto;    

    public ComponenteGarraDtoDaGarra(GarraDto garraDto)
    {
        this.garraDto = garraDto;
    }

    public float getVelocidadeMovAnguloAbertura()
    {
        return garraDto.Velocidades.MovAnguloAbertura;
    }

    public float getVelocidadeMovAnguloFechamento()
    {
        return garraDto.Velocidades.MovAnguloFechamento;
    }

    public float getVelocidadeMovAnguloIdle()
    {
        return garraDto.Velocidades.MovAnguloIdle;
    }

    public float getPosicaoCacaNiquel()
    {
        return garraDto.PosCacaNiquel;
    }

    public float getPosicaoLimiteGarra()
    {
        return garraDto.PosLimiteGarra;
    }

    public float getMassaMovimentacaoCima()
    {
        return garraDto.MassaMovCima;
    }

    public float getMassaMovimentacaoBaixo()
    {
        return garraDto.MassaMovBaixo;
    }

    public float getMassaMovimentacaoAgarrar()
    {
        return garraDto.MassaMovAgarrar;
    }
}
