using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    protected float _CameraDistance = 10f;
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;
    protected Vector3 _LocalRotation;
    public float OrbitDampening = 10f;
    public float MouseSensitivity = 4f;

    // Use this for initialization
    void Start () {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }
	
    private void LateUpdate()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
            _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

            //Clamp the y Rotation to horizon and not flipping over at the top
            if (_LocalRotation.y < -75f)
                _LocalRotation.y = -75f;
            else if (_LocalRotation.y > 90f)
                _LocalRotation.y = 90f;
        }

        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime));
        }
    }
}
