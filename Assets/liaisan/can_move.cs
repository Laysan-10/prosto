 
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class can_move : MonoBehaviour
{
	bool drag = true;
	 public Vector3 originalPosition;
	 Vector3 pointScreen;
	Vector3 offset;
	public bool areaReached = false;
	bool take_meal = false;
	public varka[] varka;
	static LayerMask targetlayer;
	
	Camera _camera;
	// public GameObject cub;
	void Start()
	{
	targetlayer = LayerMask.GetMask("varka");
		_camera = FindObjectOfType<Camera>();
		varka = FindObjectsOfType<varka>();
		originalPosition = transform.position;
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
	   
		if (drag)
		{
			Debug.Log("Drag");
			Collider[] varka = Physics.OverlapSphere(transform.position,transform.localScale.x, targetlayer);
			foreach(var col in varka)
			{
				
				if(col.GetComponent<varka>()==true){
				// Debug.Log("return" + col.GetComponent<varka>().CheckTriggerStay());
					if(col.GetComponent<varka>().CheckTriggerStay()==false)
					{
						gameObject.transform.position = originalPosition;//занята, значит возвращаем

					}
					
					return;
				}
			}
					
					gameObject.transform.position = originalPosition;

				

		}
		
			
		
	}
	

	
}
