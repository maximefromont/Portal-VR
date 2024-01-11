using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{

    public GameObject particleEffectPrefab;
    private GameObject instance;

    

    public void Activate () {
        instance = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        
    }

    public void Deactivate () {
        Destroy(instance);
    }

}
