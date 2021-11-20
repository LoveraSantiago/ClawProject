using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCoco : LevelColetavel
{
    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorCoco();
    }

    public class FornecedorCoco : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelCoco();
        }
    }
}
