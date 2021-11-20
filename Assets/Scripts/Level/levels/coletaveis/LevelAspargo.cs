using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAspargo : LevelColetavel
{
    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorAspargo();
    }

    public class FornecedorAspargo : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelAspargo();
        }
    }
}
