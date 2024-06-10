using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KochGenerator : MonoBehaviour
{
protected enum _axis
{
XAxis,
YAxis,
ZAxis
};
[SerializeField]
protected _axis axis = new _axis();

protected enum _initiator{
Triangle,
Square,
Pentagon,
Hexagon,
Hepagon,
Octagon
};

public struct LineSegment //okay... what is a struct?? structs are similar to a class. classes are reference types, structs are  value types.   value types are types that are declared as a variable, but reference types hold the memory adress, or reference to a variable
{
public Vector3 StartPosition{ get; set; }
public Vector3 EndPosition { get; set; }
public Vector3 Direction {get; set; }
public float Length { get; set; }

}

[SerializeField]
protected _initiator initiator = new _initiator(); 
[SerializeField]
protected AnimationCurve _generator; // using animation curve makes it easier to create new generators in the inspector
protected Keyframe[] _keys; 

protected int _generationCount;

//Basically Vector3s are used...
protected int _initiatorPointAmount;
private Vector3[] _initiatorPoint;
private Vector3 _rotateVector;
private Vector3 _rotateAxis;
private float _initialRotation;
[SerializeField]
protected float _initiatorSize;

protected Vector3[] _position;
protected Vector3[] _targetPosition; 
private List<LineSegment> _lineSegment;

private void Awake()
{

GetInitiatorPoints();   
//assign the lists and arrays!
_position = new Vector3[_initiatorPointAmount + 1];
_targetPosition = new Vector3[_initiatorPointAmount + 1];
_lineSegment = new List<LineSegment>();
_keys = _generator.keys;


_rotateVector = Quaternion.AngleAxis(_initialRotation, _rotateAxis) * _rotateVector;
for(int i = 0; i < _initiatorPointAmount; i++){
_position[i] =  _rotateVector *  _initiatorSize;
_rotateVector = Quaternion.AngleAxis(360 / _initiatorPointAmount, _rotateAxis) * _rotateVector;
}
_position[_initiatorPointAmount] = _position[0];

}

protected void KochGenerator(Vector3[] positions, bool outwords, float generatorMultiplier)
{
      _lineSegment.Clear();
      for(int i = 0; i < postions.Length - 1; i++)
      {
         LineSegment line = new LineSegment();
      line.StartPosition = position[i];
      if(i == positions.Length - 1){
         line.EndPosition = positions[0];

      } else {
      line.EndPositionPosition = position[i + 1];
      }
      line.Direction = (line.EndPosition - line.StartPosition).normalized;
      line.length = Vector3.Distance(line.EndPosition, line.StartPosition);
      _lineSegment.add(line);

      }
      //adding the line segment points to the array of lines
      list<Vector3> newPos = new list<Vector3>();
      list<Vector3> targetPos = new list<Vector3>();
      for(int i = 0; i < _lineSegment.Count; i++){
         newPos.Add(_lineSegment[i].StartPosition);
          targetPos.Add(_lineSegment[i].StartPosition);

          for(int j = 1; j < keys.length - 1; j++){
            float moveAmount = _lineSegment[i].Length * _keys[j].time;
            float heightAmount = (_lineSegment[i].Length * _keys[j].value) * generatorMultiplier;
            Vector3 movePos = _lineSegment[i].StartPosition + (_lineSegment[i].Direction * moveAmount);
            Vector3 Dir;
            if(outwords){
               Dir = Quaternion.AngleAxis(-90, _rotateAxis) * _lineSegment[i].Direction;
            } else {
               Dir = Quaternion.AngleAxis(-0, _rotateAxis) * _lineSegment[i].Direction;
            }
            newPos.add(movePos);
          }
      }
}

private void OnDrawGizmos(){
GetInitiatorPoints();   
_initiatorPoint = new Vector3[_initiatorPointAmount];


_rotateVector = Quaternion.AngleAxis(_initialRotation, _rotateAxis) * _rotateVector;
for(int i = 0; i < _initiatorPointAmount; i++){
_initiatorPoint[i] =  _rotateVector *  _initiatorSize;
_rotateVector = Quaternion.AngleAxis(360 / _initiatorPointAmount, _rotateAxis) * _rotateVector;
}//END 1st FOR LOOP

/*~~~~~BUFFER~~~~~*/

for(int i = 0; i < _initiatorPointAmount; i++)
{
Gizmos.color = Color.white;
Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
Gizmos.matrix = rotationMatrix;

if(i < _initiatorPointAmount - 1){
Gizmos.DrawLine(_initiatorPoint[i], _initiatorPoint[i + 1]);//see if it's not the last line, if not last line return to line 0!    
} else{ // 
    Gizmos.DrawLine(_initiatorPoint[i], _initiatorPoint[0]);
}
}//END 2nd FOR LOOP
} // end OnDrawGizmos


private void GetInitiatorPoints(){

    switch(initiator){
        case _initiator.Triangle:
        _initiatorPointAmount = 3;
        _initialRotation = 0;
            break;
         case _initiator.Square:
         _initiatorPointAmount = 4;
         _initialRotation = 45;
            break;
         case _initiator.Pentagon:
         _initiatorPointAmount = 5;
         _initialRotation = 36;
            break;
         case _initiator.Hexagon:
         _initiatorPointAmount = 6;
         _initialRotation = 30;
            break;
         case _initiator.Hepagon:
         _initiatorPointAmount = 7;
         _initialRotation = 25.71428f;
            break;
         case _initiator.Octagon:
         _initiatorPointAmount = 8;
         _initialRotation = 22.5f;
            break;
            default: 
      _initiatorPointAmount = 3;
      _initialRotation = 0;
                break;
    };//End switch(COME BACK TO LATER TO DEFINE WHAT A SWITCH IS!!!)

    switch(axis)
    {
      case _axis.XAxis:
_rotateVector = new Vector3(1, 0, 0);
_rotateAxis = new Vector3(0, 0, 1);
      break;
      case _axis.YAxis:
   _rotateVector = new Vector3(0, 1, 0);
   _rotateAxis = new Vector3(1, 0, 0);
      break;
      case _axis.ZAxis:
_rotateVector = new Vector3(0, 0, 1);
_rotateAxis = new Vector3(0, 1, 0);
      break;
      default: 
   _rotateVector = new Vector3(0, 1, 0);
   _rotateAxis = new Vector3(1, 0, 0);
      break;
    };
} //end GetInitiatorPoints






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}