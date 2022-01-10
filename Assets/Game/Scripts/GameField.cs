using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameField : MonoBehaviour
{
    Transform[] gameObjects;
    public List<Transform> fieldUnits = new List<Transform>();

    private void Start()
    {
        FillNodes();
    }

    /// <summary>
    /// Draws game field route
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < fieldUnits.Count; i++)
        {
            var curUnitPos = fieldUnits[i].position;

            if (i > 0)
            {
                var prevUnitPos = fieldUnits[i - 1].position;
                Gizmos.DrawLine(prevUnitPos, curUnitPos);
            }
        }
    }

    /// <summary>
    /// Add field units to unit list
    /// </summary>
    private void FillNodes()
    {
        fieldUnits.Clear();
        gameObjects = GetComponentsInChildren<Transform>();

        fieldUnits = gameObjects.Where(obj => obj != this.transform).ToList();
    }
}
