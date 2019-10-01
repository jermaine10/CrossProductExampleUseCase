using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUsingCross : MonoBehaviour
{
    public Transform Target;
    public Transform lookDirection;
     Rigidbody curRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        curRigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var curLook = lookDirection.position - this.transform.position;
        var view = Target.transform.position - curLook;
        var direction = curLook / curLook.magnitude;

        var rotationAxis = Vector3.Cross(direction, view);
        var rotationAngle = (float)Mathf.Acos(Vector3.Dot(direction, view) / direction.magnitude / view.magnitude);
        this.transform.Rotate(rotationAxis, rotationAngle);
        Debug.DrawLine(lookDirection.position, Target.position);
;    }
}
