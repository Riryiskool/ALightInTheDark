using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomNoises : MonoBehaviour
{
    [SerializeField] AudioSource source;
    float timer = 0f;
    void Update()
    {
        //float playTime = Random.Range(4f, 10f);

        timer += Time.deltaTime;

        

    }

}
