
using UnityEngine;

public class varka : MonoBehaviour
{
	[SerializeField] LayerMask targetlayer;
	[SerializeField] create_meal create_Meal;
   public void CheckTriggerStay()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position,transform.localScale.x, targetlayer); // Определяем коллайдеры в радиусе 0.5
		foreach (Collider col in colliders)
		{
			
				Debug.Log("Объект с тегом '"  + col.gameObject.name);
				col.gameObject.layer =default;//что бы объекты спавнились только из-за объекта который опр маску
				create_Meal.Spawn();
			
		}
	}
}
