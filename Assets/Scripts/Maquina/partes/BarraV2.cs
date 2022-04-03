using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraV2 : ParteEfeitoMaquinaV2
{
    public BarraV2(BarraDto barraDto)
        : base(barraDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.BARRA;
    }
}
