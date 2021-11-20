using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaca : LevelColetavel
{
    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorMaca();
    }

    public class FornecedorMaca : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelMaca();
        }
    }

}
