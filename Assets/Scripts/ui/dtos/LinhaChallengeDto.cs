using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
[System.Serializable]
public class LinhaChallengeDto 
{
    [SerializeField] private Image imgEstrela;
    [SerializeField] private Text lblTextoChallenge;

    public Image ImgEstrela { get { return imgEstrela; } }
    public Text LblTextoChallenge { get { return lblTextoChallenge; } }
}
