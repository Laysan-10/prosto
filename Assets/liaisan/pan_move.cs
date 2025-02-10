using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan_move : MonoBehaviour
{
	bool drag = true;
	 public Vector3 originalPosition;
	 Vector3 pointScreen;
	Vector3 offset;
	 
	// Start is called before the first frame update
	void Start()
	{
		originalPosition = gameObject.transform.position;
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
				Vector3 curScreenPoint = new Vector3(Input.mousePosition.x , Input.mousePosition.y, pointScreen.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				gameObject.transform.parent.transform.position = curPosition;
				
		}
	}
 void OnMouseUp()
 {
	gameObject.transform.parent.transform.position = originalPosition;
 }
}
