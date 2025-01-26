using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaDestroy : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    public bool Destruye = true;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!_particleSystem.IsAlive())
        {
            if (Destruye) Destroy(this.gameObject);
            else gameObject.SetActive(false);
        }
    }
}
