using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoV2 : ParteEfeitoMaquinaV2
{
    public ChaoV2(ChaoDto chaoDto)
        : base(chaoDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.CHAO_DENTRO;
    }
}
