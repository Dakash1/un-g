using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform _target, _old, _camera;
    public float _speed, _turnSpeed;
    public LayerMask _maskObstacles;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
     private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * _turnSpeed, 0);

        RaycastHit hit;
        if (Physics.Raycast(_target.position, _old.position - _target.position, out hit, Vector3.Distance(_target.position, _old.position), _maskObstacles)){
            _camera.position = hit.point;
        }
        else{
            _camera.position = _old.position;
        }
     }

    
}
