
using System.Globalization;
using UnityEngine;


public class can_move : MonoBehaviour
{
	bool drag = true;
	Vector3 originalPosition;
	Vector3 pointScreen;
	Vector3 offset;
	public bool areaReached = false;
	bool take_meal = false;
	public varka varka;
	
	Camera _camera;
	public GameObject cub;
	void Start()
	{
		_camera = FindObjectOfType<Camera>();
		varka = FindObjectOfType<varka>();
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
				Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
				transform.position = curPosition;
		}
	}
	void OnMouseUp()
	{
	   
		if (drag && varka!=null )
		{
			varka.CheckTriggerStay();
			
			// if (!areaReached) {  gameObject.transform.position = originalPosition;}//����������� �� ��������� ������� ���� �� � ����������.
			// else if(areaReached && take_meal) //���� � ���������� � ����� �������� ����.
			// {
			// 	// TeleportMeal(_place);
			// }
			// else if(!take_meal)
			// {
			// 	gameObject.transform.position = originalPosition;
			// }
			// 	drag = false;
		}
	}
	void  Update()
	{
		// varka.CheckTriggerStay();
	}
	
	
}
