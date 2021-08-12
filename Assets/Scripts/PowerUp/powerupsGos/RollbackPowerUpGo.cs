using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollbackPowerUpGo : AbstractPowerUpGo
{
    public RollbackPowerUpGo()
        :base(powerUpDto.VazioPUp, "rollback")
    {
    }

    public override void configurarPup()
    {
        
    }

    public override GarraInteracaoComPowerUp getObjetoDeInteracaoComGarra()
    {
        return new NaoInteracaoComGarra();
    }

    public override void iniciarPup()
    {
        
    }

    public override void resetPup()
    {
        
    }

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorRollback();
    }

    public class FornecedorRollback : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new RollbackPowerUpGo();
        }
    }
}
