using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField]
    EnemyData data;
    [SerializeField]
    GameObject explosion;
    int currHP;
    float currSpd;
    // Use this for initialization
    void Start()
    {
        currHP = data.hp;
        if (data.type == EnemyData.TYPE.BUTO_BOSS)
        {
            if (Random.Range(0f, 1f) < .5f)
                Invoke("GrowlLong", 2);
            else
                Invoke("GrowlShort", 2);
        }
        sr = GetComponent<SpriteRenderer>();
        currSpd = data.speed * ((LevelManager.Instance.levelIdx + 1) / 2.0f);
        currSpd *= Random.Range(.9f, 1.1f);
    }

    void GrowlLong()
    {
        SoundManager.getInstance().play_vOI_ButoGrowl();
    }

    void GrowlShort()
    {
        SoundManager.getInstance().play_vOI_ButoGrowlShort();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!LevelManager.Instance.isPause)
        {
            transform.Translate(0, -currSpd * Time.fixedDeltaTime, 0);
            sr.sortingOrder = Mathf.RoundToInt((8 - transform.position.y) * 5f) + 2;
        }
    }

    [SerializeField]
    Vector2 xBoundary;
    [SerializeField]
    float xMovement;
    void changeLane(int move)
    {
        if (transform.position.x + (move * xMovement) <= xBoundary.y &&
            transform.position.x + (move * xMovement) >= xBoundary.x)
        {
            transform.Translate(move * xMovement, 0, 0);
        }

    }

    public void Hit()
    {
        currHP--;
        CameraEffect.Instance.ShakeCam(.125f, .1f);
        StartCoroutine(Blink());
        if (currHP <= 0)
            Die();
        else
            SoundManager.getInstance().play_sFX_Button();
        if (data.type == EnemyData.TYPE.BUTO_BOSS)
        {

            int rand = Random.Range(-1, 2);
            while (rand == 0)
            {
                rand = Random.Range(-1, 2);
            }
            changeLane(rand);

        }
    }

    IEnumerator Blink()
    {
        sr.color = new Color(1, .3f, .3f);
        yield return new WaitForSeconds(.2f);
        sr.color = Color.white;
        yield return new WaitForSeconds(.2f);
        sr.color = new Color(1, .3f, .3f);
        yield return new WaitForSeconds(.2f);
        sr.color = Color.white;
    }

    public void Die()
    {
        LevelManager.Instance.player.AddScore(data.score);
        CameraEffect.Instance.ShakeCam(.5f, .25f);
        SoundManager.getInstance().play_vOI_ButoDie();
        GameObject blood = Instantiate(explosion, transform.position, new Quaternion(), null);


#if UNITY_ANDROID
        if (data.type == EnemyData.TYPE.BUTO_BOSS)
            Handheld.Vibrate();
#endif

        Destroy(blood, 2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Projectile"))
        {
            Hit();
        }

    }

}
