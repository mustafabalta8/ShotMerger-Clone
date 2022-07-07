using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private bool mouseClicked;
    public float MoveFactorX => _moveFactorX;


    public bool MouseClicked { get => mouseClicked; }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
            //mouseClicked = true;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
            //mouseClicked = false;
        }
    }
}
