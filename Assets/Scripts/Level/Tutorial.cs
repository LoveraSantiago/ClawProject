using UnityEngine;
using System.Collections;

public class Tutorial 
{
    private readonly int ANIM_COLETAR = Animator.StringToHash("clique-coletar");    

    public IEnumerator iniciar(MainGameDto mainDto)
    {
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        yield return new WaitForSeconds(mainDto.DelayInicio);

        mainDto.TutorialDto.TranformGoTutorial.localPosition = new Vector3(0.48f, 0, 0);
        mainDto.TutorialDto.TransformPonto.localPosition     = new Vector3(-0.45f, 0.54f, 0);
        mainDto.TutorialDto.TransformMao.localPosition       = Vector3.zero;
        mainDto.TutorialDto.TransformText.localPosition      = new Vector3(0.07f, -1.1f, 0);
        mainDto.TutorialDto.LblTexto.text = "Clique para acionar a garra";

        mainDto.TutorialDto.Animator.Play(ANIM_COLETAR);
        yield return new WaitForSeconds(mainDto.DelayInicio);
    }
}
