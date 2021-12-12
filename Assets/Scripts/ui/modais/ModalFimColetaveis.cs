using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalFimColetaveis : AbstractModalFim
{
    protected override void irParaCena()
    {
        CenaUtils.irParaCenaColetaveis();
    }
}
