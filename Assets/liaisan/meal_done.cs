using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meal_done : MonoBehaviour
{
	[SerializeField] LayerMask targetlayer;
	public bool Pan_meal_done()
	{
			Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position,gameObject.transform.localScale.z, targetlayer); // Определяем коллайдеры в радиусе 0.5
		if(colliders.Length == 0)
			{
				Debug.Log("NULL COL");
				return false;
			}
		
		foreach (Collider col in colliders)
		{
			
			Debug.Log("col "+col.name);
			return true;
		}
		
		return false;
		
	}
}
