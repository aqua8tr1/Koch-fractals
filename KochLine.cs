using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator
{
LineRenderer _lineRenderer;
[Range(0,1)]
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
        _lerpPosition = new Vector3[_position.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(_generationCount != 0)
        {
            for(int i = 0; i < _position.Length; i++) 
            {
                _lerpPosition[i] = Vector3.Lerp(_position[i], _targetPosition[i], _lerpAmount);
            }           
            if(_useBezierCurves)
            {
                _bezierPosition = BezierCurve(_lerpPosition, _bezierVertexCount);
                _lineRenderer.positionCount = _bezierPosition.Length;
                _lineRenderer.SetPositions(_bezierPosition);
            } 
            else
            {
                _lineRenderer.positionCount = _lerpPosition.Length;
                _lineRenderer.SetPositions(_lerpPosition);
            }

            
        }

       
    }
}
