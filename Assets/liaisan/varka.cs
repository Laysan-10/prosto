
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class varka : MonoBehaviour
{
	[SerializeField] LayerMask targetlayer;
	[SerializeField] create_meal create_Meal;
	MeshRenderer _water;
	Clock _clock;
	bool _is_use = false;
	void Awake()
	{
		var child_1_in_pan = gameObject.GetComponentsInChildren<Transform>();
		_water = child_1_in_pan[1].gameObject.GetComponent<MeshRenderer>();
		child_1_in_pan[1].gameObject.GetComponent<Collider>().enabled = false;
		_water.enabled = false;
		_clock = gameObject.GetComponentInChildren<Clock>();
		
	}
	
	
   public bool CheckTriggerStay()
	{
			Debug.Log("Start"+_is_use);
		
		if(_is_use == false)
		{
			Collider[] colliders = Physics.OverlapSphere(transform.position,transform.localScale.x, targetlayer); // Определяем коллайдеры в радиусе 0.5
		// Debug.Log("About Collider" + (colliders == null));
			
		foreach (Collider col in colliders)
		{
			
				// Debug.Log("Объект с тегом '"  + col.gameObject.name);
				// Debug.Log("About Collider" + colliders == null);
				col.gameObject.layer = default;//что бы объекты спавнились только из-за объекта который опр маску
				col.gameObject.transform.position = gameObject.transform.position;
				col.GetComponent<can_move>().originalPosition = gameObject.transform.position;
				create_Meal.Spawn();
				_is_use = true;
				_water.enabled = true;
				// foreach(var child in mesh)
				// {
				// 	child.GetComponent<MeshRenderer>().enabled = true;
				// 	Debug.Log(child.name);
				// }	
				_clock.enabled = true;
				return true;
		}
		
		}
			Debug.Log("ENd" + _is_use);
		
		return false;
	}
}
