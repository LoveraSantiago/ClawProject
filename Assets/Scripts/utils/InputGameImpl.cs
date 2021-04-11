using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGameImpl : InputGame
{
    public bool aconteceuTapNaAreaJogavel()
    {
        return Input.GetMouseButtonDown(0);
    }
}
