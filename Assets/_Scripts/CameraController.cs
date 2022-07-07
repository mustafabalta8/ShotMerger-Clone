using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float lerpValue;

    private void LateUpdate()
    {
        MoveCamera();
    }
    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue * Time.deltaTime);
        /*Vector3 cameraNewPos = target.position + offset;
        transform.position = new Vector3(Mathf.SmoothDamp(cameraNewPos.x, target.transform.position.x, ref camVelocity_x,camSpeed), 
            cameraNewPos.y, cameraNewPos.z);*/
    }
}
