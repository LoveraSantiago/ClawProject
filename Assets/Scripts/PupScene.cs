using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupScene : MonoBehaviour
{
    [SerializeField] MainCanvasDto mainCanvasDto;

    // Start is called before the first frame update
    void Start()
    {
        MainCanvasPup mainCanvas = new MainCanvasPup(mainCanvasDto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
