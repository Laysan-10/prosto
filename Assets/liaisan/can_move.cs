using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class can_move : MonoBehaviour
{
	
	public Rigidbody _selectedObject;
	Vector3 _mousePosition;
	Vector3 _offset;
	public float _maxSpeed=10;
	Vector2 _mouseForce;
	Vector3 _lastPosition;
	Camera _camera;
	void Start()
	{
		_camera = FindObjectOfType<Camera>();
	}
	void Update()
	{
		_mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
		
		if(_selectedObject)
		{
			Debug.Log("Update_1");
			_mouseForce = (_mousePosition - _lastPosition) / Time.deltaTime;
				_mouseForce = Vector2.ClampMagnitude(_mouseForce, _maxSpeed);
				_lastPosition = _mousePosition;
		}
		if(Input.GetMouseButtonDown(0))
		{
			Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(_ray, out hit))
			{
				// _mouseForce = (_mousePosition - _lastPosition) / Time.deltaTime;
				// _mouseForce = Vector2.ClampMagnitude(_mouseForce, _maxSpeed);
				// _lastPosition = _mousePosition;
				_selectedObject = hit.transform.gameObject.GetComponent<Rigidbody>();
				_offset = _selectedObject.transform.position - _mousePosition;
				Debug.Log(hit.transform.gameObject.name);
				// hit.transform.position = _mousePosition;
				// hit.transform.GetComponent<Rigidbody>().MovePosition(_mousePosition);

			{
		}
			Debug.Log(Input.GetMouseButtonUp(1));
			Debug.Log( _selectedObject);
			
		
		if(Input.GetMouseButtonUp(0) && _selectedObject)
		{
			// Debug.Log(Input.GetMouseButtonUp(0) && _selectedObject);
			 _selectedObject = null;
		}
		if(_selectedObject)
		{
			Debug.Log("Fixed_Update");
			// _selectedObject.MovePosition(_mousePosition + _offset);
			_selectedObject.transform.position = _mousePosition + _offset;
		}
		
	}
	void FixedUpdate()
	{
		// if(_selectedObject)
		// {
		// 	Debug.Log("Fixed_Update");
		// 	_selectedObject.MovePosition(_mousePosition + _offset);
		// }
	}
		
}
	}
}
