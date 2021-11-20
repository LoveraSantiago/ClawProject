using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLeite : LevelColetavel
{
    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLeite();
    }

    public class FornecedorLeite : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLeite();
        }
    }

}
