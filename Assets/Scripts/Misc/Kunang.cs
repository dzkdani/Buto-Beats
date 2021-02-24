using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunang : MonoBehaviour
{
    [SerializeField]
    public float spd;

    Vector3 origin;
    float seedCos;
    void Start()
    {
        origin = transform.localPosition;
        seedCos = Random.Range(2f,-2f);
    }

    float elapsed;
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        transform.localPosition = new Vector3(
            origin.x + Mathf.Sin(elapsed * spd * seedCos),
            origin.y + Mathf.Cos(elapsed * spd),
            0);
    }
}
