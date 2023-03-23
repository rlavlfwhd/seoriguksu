using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PositionList : MonoBehaviour
{
    public List<Vector3> positionList;
    public List<Vector3> filter_positionList;
    void Start()
    {
        LINQFunction();
    }

    public void LINQFunction()
    {
        filter_positionList = new List<Vector3>();

        filter_positionList = positionList
            .Where(n => Vector3.Distance(transform.position, n) > 2f)
            .OrderBy(n => Vector3.Distance(transform.position, n))
            .ToList();
    }
}
