using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class DisplayTimerDto {
    
    [Space(5)]
    [SerializeField] private SingleDisplayTimerDto[] singleDisplay = new SingleDisplayTimerDto[5];    

    public SingleDisplayTimerDto[] SingleDisplay { get { return singleDisplay; } }
}
