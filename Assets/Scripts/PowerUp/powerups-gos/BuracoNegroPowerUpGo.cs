using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoNegroPowerUpGo : AbstractAsaPowerUpGo
{
    public BuracoNegroPowerUpGo() : 
        base(powerUpDto.AsaDto.AsaGo, "Buraco Negro"){}

    protected override IEnumerator finalizarVoar(Coletavel coletavelAcertado)
    {
        throw new System.NotImplementedException();
    }

    protected override float getGravidadeNegativa()
    {
        throw new System.NotImplementedException();
    }

    protected override float getHalturaLimite()
    {
        throw new System.NotImplementedException();
    }

    protected override float getOffset()
    {
        throw new System.NotImplementedException();
    }
}
