using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalFimOrdem : AbstractModalFim
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {        
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
