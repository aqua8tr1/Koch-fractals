using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KochGenerator : MonoBehaviour
{


protected enum _initiator{
Triangle,
Square,
Pentagon,
Hexagon,
Hepagon,
Octagon
};
[SerializeField]
protected _initiator initiator = new _initiator(); 

protected int _initiatorPointAmount;
private Vector3[] _initiatorPoint;
private Vector3 _rotateVector;
[SerializeField]
protected float initiatorSize;


private void OnDrawGizmos(){
GetInitiatorPoints();   
_initiatorPoint = new Vector3[_initiatorPointAmount];

_rotateVector = new Vector3(0, 0, 1);

for(int i = 0; i < _initiatorPointAmount; i++){


}
}


private void GetInitiatorPoints(){

    switch(initiator){
        case _initiator.Triangle:
        _initiatorPointAmount = 3;
            break;
         case _initiator.Square:
         _initiatorPointAmount = 4;
            break;
         case _initiator.Pentagon:
         _initiatorPointAmount = 5;
            break;
         case _initiator.Hexagon:
         _initiatorPointAmount = 6;
            break;
         case _initiator.Hepagon:
         _initiatorPointAmount = 7;
            break;
         case _initiator.Octagon:
         _initiatorPointAmount = 8;
            break;
            default: 
_initiatorPointAmount = 3;
                break;
    };
}






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
