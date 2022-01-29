using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private PlayerRotation _playerRotation;
    private Vector3 _positionOnScene;
    private Quaternion _rotationOnScene;
    private Vector3 _lastMousePosition;
    private float _distanceToPlayer;
    private bool _isPickedUp = false;
    private bool _onHover = false;
    private Vector3 _onPickedUpCubePosition = new Vector3(0.27f, 7.08f, 2.37f);

    private void Start()
    {
        _agent = FindObjectOfType<NavMeshAgent>();
        _playerRotation = FindObjectOfType<PlayerRotation>();
    }

    private void Update()
    {
        if (_onHover && Input.GetKeyDown(KeyCode.F))
        {
            _distanceToPlayer = Vector3.Distance(_agent.transform.position, transform.position);

            if (_distanceToPlayer < 1.5f)
            {
                _agent.isStopped = true;
                _playerRotation.isActive = false;
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
            _agent.isStopped = false;
            _playerRotation.isActive = true;

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
