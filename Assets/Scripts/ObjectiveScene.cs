using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScene : MonoBehaviour
{
    public static ObjectiveScene Instance { get; private set; }

    [SerializeField] private List<Objective> objectivesList;
    private int currentObjectiveNumber = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ObjectiveScene is already there, destroying" + gameObject);
            Destroy(gameObject);
        }

        Instance = this;
    }




    public void CheckCurrentObjective()
    {
        if (currentObjectiveNumber > objectivesList.Count)
        {
            Debug.LogError("objectiveNumber is greater than the amount of objectives!");
        }

        Objective objective = objectivesList[currentObjectiveNumber];

        if (objective.isTrigger)
        {
            if (objective.triggerCollider != null)
            {
          //      if (objective.triggerCollider == 
            }
        }
    }

    public void IsTriggerTheObjective(Collider trigger) {

        if (currentObjectiveNumber > objectivesList.Count)
        {
            Debug.LogError("objectiveNumber is greater than the amount of objectives!");
        }

        Objective objective = objectivesList[currentObjectiveNumber];

        if (objective.isTrigger && objective.triggerCollider != null)
        {
            if (objective.triggerCollider == trigger) Debug.Log("In Trigger");
            
        }
    }

    public void IsInteractTheObjective(InteractableObjective intObj)
    {
        if (currentObjectiveNumber > objectivesList.Count)
        {
            Debug.LogError("objectiveNumber is greater than the amount of objectives!");
        }

        Objective objective = objectivesList[currentObjectiveNumber];


        Debug.Log(objective.interactableObject);
        Debug.Log(intObj);
        Debug.Log(objective.interactableObject == intObj);
        if (!objective.isTrigger && objective.interactableObject != null)
        {
            Debug.Log("here");
            if (objective.interactableObject == intObj) Debug.Log("In Interact");

        }
    }

}
