using UnityEngine;

public class GameManager : MonoBehaviour
{
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void ActivateObject(GameObject obj)
	{
		if(obj.activeSelf) obj.SetActive(false);
		else obj.SetActive(true);
	}
}
