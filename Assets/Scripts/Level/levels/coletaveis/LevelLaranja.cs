using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLaranja : LevelColetavel
{
    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLaranja();
    }

    public class FornecedorLaranja : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLaranja();
        }
    }
}
