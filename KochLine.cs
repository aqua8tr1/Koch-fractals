using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator
{
LineRenderer _lineRenderer;
public float _lerpAmount;
Vector3[] _lerpPosition;
public float _generateMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = true; //with .enabled, .useWorldSpace, and .loop we are setting the values we want at start(the first frame) so they stay like that regardless of what settings we fw in the line renderer!
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.loop = true;
        _lineRenderer.positionCount = _position.Length;
        _lineRenderer.SetPositions(_position);
    }

    // Update is called once per frame
    void Update()
    {
        if(input.GetKeyUp(KeyCode.O))
        {
            KochGenerate(_targetPosition, true, _generateMultiplier);
        }
        if(input.GetKeyUp(KeyCode.I))
        {
            KochGenerate(_targetPosition, true, _generateMultiplier);
        }
    }
}
