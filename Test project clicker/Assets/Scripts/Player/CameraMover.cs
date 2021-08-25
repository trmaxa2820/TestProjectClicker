using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _depth;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;

    private Vector3 _touch;

    private void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _depth);
        
        if (Input.GetMouseButtonDown(0))
        {
            _touch = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _touch - Camera.main.ScreenToWorldPoint(mousePosition);
            direction = new Vector3(direction.x, 0, direction.z);
            Camera.main.transform.position += direction * Time.deltaTime * _moveSpeed;
        }

        ClampCameraPozition();
    }

    private void ClampCameraPozition()
    {
        float pozitionX = Mathf.Clamp(Camera.main.transform.position.x, _minPositionX, _maxPositionX);
        float pozitionZ = Mathf.Clamp(Camera.main.transform.position.z, _minPositionZ, _maxPositionZ);
        Camera.main.transform.position = new Vector3(pozitionX, Camera.main.transform.position.y, pozitionZ);
    }
}
