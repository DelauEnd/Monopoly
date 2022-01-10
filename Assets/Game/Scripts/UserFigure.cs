using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserFigure : MonoBehaviour
{
    public GameField gameField;
    public int currentPosition = 0;
    public int steps;
    public uint userMoney = 1500;
    public bool isMoving;
    public bool shouldMove;
    public bool moveEnded;

    private void Start()
    {
        gameField = transform.parent.parent.GetComponentInChildren<GameField>();
    }

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            moveEnded = false;
            StartCoroutine(Move());
            shouldMove = false;
            moveEnded = true;
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            currentPosition++;
            currentPosition %= gameField.fieldUnits.Count;

            if (currentPosition == 0)
                LoopPased();

            var nextPos = gameField.fieldUnits[currentPosition].position;
            while (ShouldMoveToNext(nextPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
            steps--;
        }

        MoveOver();
        isMoving = false;
    }

    private void MoveOver()
    {
        Debug.Log("final position:" + currentPosition);
    }

    private void LoopPased()
    {
        userMoney += 200;
        Debug.Log("Loop pased, user money:" + userMoney);
    }

    bool ShouldMoveToNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.fixedDeltaTime));
    }
}
