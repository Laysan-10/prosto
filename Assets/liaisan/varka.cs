
using UnityEngine;

public class varka : MonoBehaviour
{
	[SerializeField] LayerMask targetlayer;
	[SerializeField] create_meal create_Meal;
	bool _is_use = false;
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
				return true;
		}
		
		}
			Debug.Log("ENd" + _is_use);
		
		return false;
	}
}
