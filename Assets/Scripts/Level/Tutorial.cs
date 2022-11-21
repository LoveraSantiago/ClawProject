using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial 
{
    public void addDto(TutorialDto tutorialDto)
    {
        tutorialDto.GoTutorial.SetActive(true);

        tutorialDto.TranformGoTutorial.localPosition = new Vector3(0.48f, 0, 0);
        tutorialDto.TransformPonto.localPosition     = new Vector3(-0.45f, 0.54f, 0);
        tutorialDto.TransformMao.localPosition       = Vector3.zero;
        tutorialDto.TransformText.localPosition      = new Vector3(0.07f, -1.1f, 0);
        tutorialDto.LblTexto.text = "Clique para acionar a garra \nX vezes";
    }
}
