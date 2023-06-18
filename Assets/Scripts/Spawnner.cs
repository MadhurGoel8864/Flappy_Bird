using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{

    public GameObject prefab;

    public float SpwanRate = 4f;
    public float minHeight= -1.5f;
    public float maxHeight= 2.5f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),SpwanRate, SpwanRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
//        InvokeRepeating(nameof(Spawn),SpwanRate, SpwanRate);
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position,Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
         
    }








}




