using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
	[Header("Set in Inspector")] //��������� � ����������
	public GameObject dragonEggPrefab; //������ ����
	public float speed = 3f;
	public float timeBetweenEggDrops = 1f; //�������� ��������� ���
	public float leftRightDistance = 10f; //��� ���������� �� ���� ������ �� �������
	public float chanceDirections = 0.01f; //����������� ��������� ����������� ��������

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
		Vector3 pos = transform.position; //1 ������� ������� �������
		pos.x += speed * Time.deltaTime; //2 ��������� ����
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
