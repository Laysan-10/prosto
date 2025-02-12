using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pan_move : MonoBehaviour
{
	bool drag = true;
	 public Vector3 originalPosition;
	 Vector3 pointScreen;
	Vector3 offset;
	 private float zCoordinate;
	 meal_done meal_done;
	 
	// Start is called before the first frame update
	void Awake()
	{
		originalPosition = gameObject.transform.position;
		meal_done = FindFirstObjectByType<meal_done>();
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public  void OnMouseDown()
	{
		
		pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//смещение объекта относительно мыши
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));
		
		drag = true;
		
	}
	public void OnMouseDrag()
	{
		if (drag)
		{
				Vector3 curScreenPoint = new Vector3(Input.mousePosition.x ,  Input.mousePosition.y, pointScreen.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				
				gameObject.transform.parent.transform.position =  Vector3.Lerp(gameObject.transform.parent.transform.position, curPosition, 0.1f);
				
				
		}
	}
	private Vector3 GetMouseWorldPosition()
	{
		// Получаем позицию мыши в мировых координатах
		Vector3 mousePoint = Input.mousePosition;
		
		mousePoint.z  = zCoordinate;
		zCoordinate = zCoordinate / 2;
		return new Vector3(0, 0, Camera.main.ScreenToWorldPoint(mousePoint).z/2);
	}
 void OnMouseUp()
 {
	if(meal_done.Pan_meal_done() == false)
	{
		gameObject.transform.parent.transform.position = originalPosition;
	}
	
 }
}
