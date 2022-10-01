public class EstadoContadorDeColetaveis 
{
    private readonly int ESTADO_INICIAL               = 0;
    private readonly int ESTADO_TRINCA_SUCESSO        = 1;
    private readonly int ESTADO_TRINCA_FAIL_PREMATURO = 2;
    private int estado;

    public bool isTrincaSucesso { get { return estado == ESTADO_TRINCA_SUCESSO; } }
    public bool isFailPrematuro { get { return estado == ESTADO_TRINCA_FAIL_PREMATURO; } }

    public EstadoContadorDeColetaveis()
    {
        reset();
    }

    public void reset()
    {
        estado = ESTADO_INICIAL;
    }

    public void coletadoTrincaSucesso()
    {
        estado = ESTADO_TRINCA_SUCESSO;
    }

    public void coletadoFailPrematuro()
    {
        estado = ESTADO_TRINCA_FAIL_PREMATURO;
    }
}
