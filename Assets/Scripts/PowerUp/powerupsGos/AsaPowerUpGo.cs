using UnityEngine;

public class AsaPowerUpGo : AbstractPowerUpGo
{
    public AsaPowerUpGo() 
        : base(powerUpDto.AsaPup, "Asas")
    {
    }

    public override void configurarPup()
    {
        
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        throw new System.NotImplementedException();
    }

    public override void iniciarPup()
    {
        throw new System.NotImplementedException();
    }

    public override void resetPup()
    {
        throw new System.NotImplementedException();
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
