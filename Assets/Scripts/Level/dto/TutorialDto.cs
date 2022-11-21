using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TutorialDto 
{    
    [SerializeField] private GameObject goTutorial;

    public GameObject GoTutorial { get { return goTutorial; } }
}
