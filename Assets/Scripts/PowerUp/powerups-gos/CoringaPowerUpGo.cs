using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    public CoringaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome)
    {
    }

    public override void configurarPup()
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

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorCoringa();
    }

    public class FornecedorCoringa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new CoringaPowerUpGo();
        }
    }
}
