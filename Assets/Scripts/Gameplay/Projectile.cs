using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    Color[] colors;

    [SerializeField]
    TrailRenderer[] trails;

    float y_speed = 15f;
    float waveFreq = 7.5f;
    float x_offset = .2f;
    float elapsed = 0;
    // Use this for initialization
    void Start()
    {
        x_offset *= Random.Range(-2f, 2f);
        waveFreq *= Random.Range(.75f, 1.5f);

        Color randomColor = colors[Random.Range(0, colors.Length)];

        foreach (var item in trails)
        {
            item.startColor = new Color(
                randomColor.r,
                randomColor.g,
                randomColor.b,
                item.startColor.a);
            randomColor *= .9f;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!LevelManager.Instance.isPause)
        {
            elapsed += Time.fixedDeltaTime;
            Vector3 newPos = new Vector3(Mathf.Sin(elapsed * waveFreq) * x_offset, y_speed * elapsed, 0);
            transform.localPosition = newPos;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
