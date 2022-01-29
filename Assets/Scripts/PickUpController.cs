using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _positionOnScene;
    private Quaternion _rotationOnScene;
    private Vector3 _lastMousePosition;
    private bool _isPickedUp = false;
    private bool _onHover = false;
    private Vector3 _onPickedUpCubePosition = new Vector3(0.27f, 7.08f, 2.37f);

    private void Start()
    {
        _agent = FindObjectOfType<NavMeshAgent>();
    }

    private void Update()
    {
        if (_onHover && Input.GetKeyDown(KeyCode.F))
        {
            _agent.isStopped = true;
            _positionOnScene = transform.position;
            _rotationOnScene = transform.rotation;
            _isPickedUp = true;

            switch (gameObject.tag)
            {
                case "Cube":
                    transform.position = _onPickedUpCubePosition;
                    break;
                case "Knife":
                    transform.position = _onPickedUpCubePosition;
                    break;
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

        if (_isPickedUp && Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = _positionOnScene;
            transform.rotation = _rotationOnScene;
            _isPickedUp = false;
            _agent.isStopped = false;
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
