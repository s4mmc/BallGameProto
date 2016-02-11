using UnityEngine;
using System.Collections;

public class hitParticleDestroy : MonoBehaviour {
    public float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(DestroyAfterTime());
        
	}

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
