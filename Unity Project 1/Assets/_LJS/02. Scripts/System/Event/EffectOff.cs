using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class EffectOff : MonoBehaviour
{
	// If true, deactivate the object instead of destroying it
	public bool OnlyDeactivate;
	public GameObject effect;

	void OnEnable()
	{
		StartCoroutine(CheckIfAlive());
	}

	IEnumerator CheckIfAlive()
	{
		ParticleSystem ps = this.GetComponent<ParticleSystem>();

		while (true && ps != null)
		{
			yield return new WaitForSeconds(0.5f);
			if (!ps.IsAlive(true))
			{
				if (OnlyDeactivate)
				{
#if UNITY_3_5
					this.gameObject.SetActiveRecursively(false);
#else
					effect.gameObject.SetActive(false);
#endif
				}
				else
					Destroy(effect.gameObject);
				break;
			}
		}
	}
}