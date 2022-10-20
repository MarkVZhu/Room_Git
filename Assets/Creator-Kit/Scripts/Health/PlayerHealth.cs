using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.UI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int blinks;
    public GameObject blinkImage;
    public float time;
    public float dieTime;
    public float hitBoxCdTime;
    public int headacheDamage;
    public float hDamageTimeInterval;
    public GameObject DeathMessage;

    [SerializeField] private Sprite deathSprite;
    private Image myRender;
    private Animator anim;
    //private ScreenFlash sf;
    private Rigidbody2D rb2d;
    private PolygonCollider2D polygonCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        //HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        myRender = blinkImage.GetComponent<Image>();
        //sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();

        if (!State.Instance.takeDrug1)
            InvokeRepeating("HeadacheDamage", 1f, hDamageTimeInterval);
    }

    public void DamagePlayer(int damage)
    {
        //sf.FlashScreen();
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);
            //rb2d.gravityScale = 0.0f;
            //GameController.isGameAlive = false;
            CancelInvoke("HeadacheDamage");
            if (this.GetComponent<PlayerControllerBox>())
                this.GetComponent<PlayerControllerBox>().canInput = false;
            if (this.GetComponent<CharacterController2DPlatform>())
                this.GetComponent<CharacterController2DPlatform>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = deathSprite;
            if (this.GetComponent<Animator>()&& GameObject.Find("Controllers"))
            {
                this.GetComponent<Animator>().enabled = false;
                GameObject.Find("Controllers").GetComponent<InputControllerPlatform>().enabled = false;
            }

            if(DeathMessage)
                DeathMessage.SetActive(true);
        }
        BlinkPlayer(blinks, time);
        //polygonCollider2D.enabled = false;
        //StartCoroutine(ShowPlayerHitBox());
    }

    private void HeadacheDamage()
    {
        DamagePlayer(headacheDamage);
    }

    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        //polygonCollider2D.enabled = true;
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }

    public void StopInvoke()
    {
        CancelInvoke("HeadacheDamage");
        Debug.Log("Cancel");
    }
}