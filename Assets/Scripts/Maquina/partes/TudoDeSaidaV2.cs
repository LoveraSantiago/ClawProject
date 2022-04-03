using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudoDeSaidaV2 : ParteEfeitoMaquinaV2
{
    public TudoDeSaidaV2(TuboDto tuboDto)
        : base(tuboDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.TUBO;
    }

    protected override float getTransparencia()
    {
        return 0.88f;
    }
}
