using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
	[Header("Set in Inspector")] //Заголовок в инспекторе
	public GameObject dragonEggPrefab; //префаб яйца
	public float speed = 3f;
	public float timeBetweenEggDrops = 1f; //Скарость генерации яиц
	public float leftRightDistance = 10f; //мин расстояние от края экрана до дракона
	public float chanceDirections = 0.01f; //вероятность изменения направления движения

	// Start is called before the first frame update
	void Start()
    {
		Invoke("DropEgg", 2f); // 1
	}

	void DropEgg() // 2
	{
		Vector3 myVector = new
		Vector3(0.0f, 5.0f, 0.0f);
		GameObject egg =
		Instantiate<GameObject>(dragonEggPrefab);
		egg.transform.position = transform.position + myVector;
		Invoke("DropEgg", timeBetweenEggDrops);
	}

	// Update is called once per frame
	void Update()
    {
		Vector3 pos = transform.position; //1 Текущая позиция объекта
		pos.x += speed * Time.deltaTime; //2 Плпвность игры
		transform.position = pos; //3 
		if (pos.x < -leftRightDistance) //1
		{
			speed = Mathf.Abs(speed);
		}
		else if (pos.x > leftRightDistance) //2
		{
			speed = -Mathf.Abs(speed);
		}

	}
	private void FixedUpdate()
	{
		if (Random.value < chanceDirections)
		{
			speed *= -1;
		}
	}

}
