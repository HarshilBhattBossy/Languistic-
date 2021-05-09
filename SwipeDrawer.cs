using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDrawer : MonoBehaviour
{

    private LineRenderer lineRender;
    private float zOffset = 10;
    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
        Algo.OnSwipe += SwipeDetect;
    }

    private void SwipeDetect(SwipeData data)
    {

        Vector3[] positon = new Vector3[2];
        positon[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPos.x, data.StartPos.y, zOffset));
        positon[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPos.x, data.EndPos.y, zOffset));
        lineRender.positionCount = 2;
        lineRender.SetPositions(positon);

    }

}