using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamelan : MonoBehaviour
{
    [SerializeField]
    KeyCode key;

    SpriteRenderer sr;
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float cooldown;
    public float currCD;
    [SerializeField]

    AudioClip sFX_Gamelan;
    [SerializeField]
    float sFX_volume;
    // Use this for initialization
    void Start()
    {
        currCD = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currCD -= Time.deltaTime;
        if (currCD <= 0) currCD = 0;
        if (Input.GetKeyDown(key))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        if (!LevelManager.Instance.isPause)
        {
            StartCoroutine(Blink());
            if (currCD <= 0)
            {
                DeployProjectile();
                currCD = cooldown;
                SoundManager.getInstance().play_sFX_Gamelan(sFX_Gamelan, sFX_volume);
            }
        }

    }

    IEnumerator Blink()
    {
        sr.color = Color.grey;
        yield return new WaitForSeconds(.1f);
        sr.color = Color.white;
    }

    private void DeployProjectile()
    {
        if (LevelManager.Instance.player.TakePoint(1))
            Instantiate(projectile, transform, false);
    }
}
