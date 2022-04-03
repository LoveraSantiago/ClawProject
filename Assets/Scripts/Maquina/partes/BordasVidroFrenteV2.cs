using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordasVidroFrenteV2 : ParteEfeitoMaquinaV2
{
    public BordasVidroFrenteV2(BordasFrenteDto bordasDto)
        : base(bordasDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.BORDA_VIDRO;
    }
}
