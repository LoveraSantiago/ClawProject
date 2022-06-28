using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{
    [SerializeField] private int qtdLinhas;
    [SerializeField] private RectTransform rTransformScroll;
    [SerializeField] 

    void Start()
    {
        Debug.Log("Pos antes " + rTransformScroll.offsetMin);
        //rTransformScroll.offsetMin -= new Vector2(rTransformScroll.offsetMin.x, (qtdLinhas - 1) * 400);
        Debug.Log("Pos depois " + rTransformScroll.offsetMin);
    }
}
