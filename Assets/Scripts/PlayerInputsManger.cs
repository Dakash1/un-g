using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputsManger : MonoBehaviour
{
    public Vector2 look;
    void OnLook(InputValue value){
        look = value.Get<Vector2>();
    }
}
