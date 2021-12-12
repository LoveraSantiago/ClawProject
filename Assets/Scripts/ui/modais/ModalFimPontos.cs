using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalFimPontos : AbstractModalFim
{
    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
