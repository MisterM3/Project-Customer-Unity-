using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScene : MonoBehaviour
{
    public static ObjectiveScene Instance { get; private set; }

    [SerializeField] private List<Objective> objectivesList;
    [SerializeField] private int currentObjectiveNumber = 0;

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
            if (objective.triggerCollider == trigger) NextObjective();
            
        }
    }

    public void IsInteractTheObjective(InteractableObjective intObj)
    {
        if (currentObjectiveNumber > objectivesList.Count)
        {
            Debug.LogError("objectiveNumber is greater than the amount of objectives!");
        }

        Objective objective = objectivesList[currentObjectiveNumber];

        if (!objective.isTrigger && objective.interactableObject != null)
        {
            if (objective.interactableObject == intObj) NextObjective();

        }
    }

    private void NextObjective()
    {
        currentObjectiveNumber++;
        MissionUI.Instance.NextMission();
        if (currentObjectiveNumber > objectivesList.Count)
        {
            Debug.LogError("Objectivenumber is above count");
            return;
        }
        if (currentObjectiveNumber == objectivesList.Count)
        {
            Debug.Log("next scene");
            MySceneManager.instance.NextScene();

        }
    }

    public int GetCurrentObjective()
    {
        return currentObjectiveNumber;
    }

}
