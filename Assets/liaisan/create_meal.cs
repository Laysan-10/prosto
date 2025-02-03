using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_meal : MonoBehaviour
{
	[SerializeField] GameObject _meal;
	public void Spawn()//можно сделать массив с тегами и каждый тег вызывает свой метол или проста меняет место спавна
	{
	
		Instantiate(_meal);
	}
}
