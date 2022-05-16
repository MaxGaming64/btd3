using UnityEngine;

public class BillboardY : MonoBehaviour
{
	void LateUpdate()
	{
		transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
	}
}
