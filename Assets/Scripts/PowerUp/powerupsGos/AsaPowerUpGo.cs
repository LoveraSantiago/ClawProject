using UnityEngine;

public class AsaPowerUpGo : AbstractPowerUpGo
{
    private readonly int VOADA;
    private Animator animator;

    public AsaPowerUpGo() 
        : base(powerUpDto.AsaPup, "Asas")
    {
        VOADA = Animator.StringToHash("voada");
    }

    public override void configurarPup()
    {
        animator = goColetavel.GetComponent<Animator>();
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void iniciarPup()
    {
        
    }

    public override void resetPup()
    {
        
    }

    public static Supplier<AbstractPowerUpGo> getSupplier()
    {
        return new Supplier();
    }

    public class Supplier : Supplier<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo get()
        {
            return new AsaPowerUpGo();
        }
    }
}
