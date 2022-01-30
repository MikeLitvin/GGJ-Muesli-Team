using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpController : MonoBehaviour
{
    private ClickToMove _ctmScript;
    private PlayerRotation _playerRotation;
    private Vector3 _positionOnScene;
    private Quaternion _rotationOnScene;
    private Vector3 _lastMousePosition;
    private float _distanceToPlayer;
    private bool _isPickedUp = false;
    private bool _onHover = false;
    private Vector3 _onPickedUpPosition = new Vector3(4.16f, 2.11f, 3.38f);

    private void Start()
    {
        _ctmScript = FindObjectOfType<ClickToMove>();
        _playerRotation = FindObjectOfType<PlayerRotation>();
        _positionOnScene = transform.position;
        _rotationOnScene = transform.rotation;
    }

    private void Update()
    {
        if (_onHover && Input.GetKeyDown(KeyCode.F))
        {
            _distanceToPlayer = Vector3.Distance(_ctmScript.transform.position, transform.position);
            print(_distanceToPlayer);

            if (_distanceToPlayer < 2f)
            {
                _ctmScript.enabled = false;

                _isPickedUp = true;
                transform.position = _onPickedUpPosition;
                //switch (gameObject.tag)
                //{
                //    case "Cube":
                //        transform.position = _onPickedUpCubePosition;
                //        break;
                //    case "Knife":
                //        transform.position = _onPickedUpCubePosition;
                //        break;
                //    case "Lamp":
                //        transform.position = _onPickedUpLampPosition;
                //        break;
                //}
            }
        }

        if (_isPickedUp && Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
        }

        if (_isPickedUp && Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - _lastMousePosition;
            _lastMousePosition = Input.mousePosition;

            var axis = Quaternion.AngleAxis(90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }

        if (_isPickedUp && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _positionOnScene;
            transform.rotation = _rotationOnScene;
            _isPickedUp = false;
            _ctmScript.enabled = true;
        }
    }

    private void OnMouseEnter()
    {
        _onHover = true;
    }

    private void OnMouseExit()
    {
        _onHover = false;
    }
}
