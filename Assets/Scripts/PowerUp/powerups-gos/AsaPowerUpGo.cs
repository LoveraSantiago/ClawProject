using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : AbstractAsaPowerUpGo
{   
    public AsaPowerUpGo() 
        : base(powerUpDto.AsaDto.AsaGo, "Asas"){}              

    protected override float getHalturaLimite()
    {
        return powerUpDto.AsaDto.Haltura;
    }

    protected override IEnumerator finalizarVoar(ColetavelTile coletavelAcertado)
    {
        powerUpFinalizacao.preFinalizar(coletavelAcertado);
        desligar();

        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;        
    }


    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorAsa();
    }

    public class FornecedorAsa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new AsaPowerUpGo();
        }
    }   
}
