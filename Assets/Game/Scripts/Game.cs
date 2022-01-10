using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public LinkedList<UserFigure> users;
    public LinkedListNode<UserFigure> currentUser;
    public LinkedListNode<UserFigure> previousUser;

    public DiceCheck dices;

    private void Start()
    {
        users = new LinkedList<UserFigure>(GetComponentsInChildren<UserFigure>());
        currentUser = users.First;
        previousUser = users.Last;
        dices = GetComponentInChildren<DiceCheck>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& !currentUser.Value.isMoving && !previousUser.Value.isMoving*/)
        {
            dices.ClearRolledNumbers();
            dices.RollAllDices();
        }

         Debug.Log("check: " + dices.dicesRolled + ", " + dices.isNumbersCalculated);

        if (dices.isNumbersCalculated && dices.dicesRolled)
        {
            dices.dicesRolled = false;
            currentUser.Value.steps = dices.rolledSum;
            Debug.Log("Dice rolled: " + currentUser.Value.steps);
        }

        //if(dices.GetRolledSum() != 0 && dices.IsDicesRolled() && !currentUser.Value.isMoving && !previousUser.Value.isMoving)
        //{
        //    currentUser.Value.steps = dices.GetRolledSum();
        //    Debug.Log("Dice rolled: " + currentUser.Value.steps);
        //    currentUser.Value.shouldMove = true;
        //    NextUser();
        //}

    }

    public void NextUser()
    {
        previousUser = currentUser;
        currentUser = currentUser.Next ?? users.First;     
    }

    private void FixedUpdate()
    {
        
    }
}
