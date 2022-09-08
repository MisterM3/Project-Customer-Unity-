using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScene : MonoBehaviour
{
    [SerializeField] private List<Objective> objectivesList;


    private void Awake()
    {
        objectivesList = new List<Objective>();  
    }

}
