using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //prop
    public MovementJoystick movementJoystick;
    public float originSpeed = 4f;
    private float speed;
    public float mass = 0.6f;
    private Rigidbody2D rb;
    //UI
    public Text textScore;
    private float score = 0f;
    public Text textLife;
    public Image curentProcess;
    public GameOverScreen gameOver;
    public WinScreen gameWin;
    //audio
    public AudioClip audioEat;
    public AudioClip audioDie;
    public AudioClip audioScaleUp;
    //
    private bool isMediumSize = false;
    private bool isBigSize = false;
    public Collider2D mapBounds;
    private float startTime = 0f;

    public Player()
    {
        speed = originSpeed;
    }
    void Start()
    {
        textLife.text = "5";
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            //chuyen huong
            if (movementJoystick.joystickVec.x > 0) transform.eulerAngles = new Vector2(0, 180);
            else transform.eulerAngles = new Vector2(0, 0);
            //di chuyen
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * speed,
                                        movementJoystick.joystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private float time = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Power" :
                Destroy(collision.gameObject);
                SpeedUpIn(6); 
                break;
            case "IncreaseLife" :
                Destroy(collision.gameObject);
                InCreaseLife();
                break;
            case "Untagged" :
                ColliderProcessWithOtherFish(collision);
                break;
            default: break;
        }

        



    //if(collision.gameObject.layer == 13 && collision.gameObject.tag == "Power")
    //{
    //    AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
    //    Destroy(collision.gameObject);
    //    speed *= 3;
    //    StartCoroutine(ExecuteAfterTime(6f, () => { BackToOriginSpeed(); }));
    //}
    //else
    //if()
    //{
    //    AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
    //    Destroy(collision.gameObject);

    //}
    //khoi luong ca va cham

    }
 
    private void ColliderProcessWithOtherFish(Collider2D collision)
    {
        float massOfTheOtherGameObject = collision.gameObject.GetComponent<EnemyPathingRandom>().mass;
        // an
        if (this.mass > massOfTheOtherGameObject)
        {
            Destroy(collision.gameObject);
            Eat(massOfTheOtherGameObject);
        }
        //bi an
        else
        {
            int curentLife = Convert.ToInt32(textLife.text.Trim()) - 1;
            textLife.text = curentLife.ToString();
            if (curentLife != 0)
            {
                Die();
                Coroutine flickerCouroutine = StartCoroutine(FlickerEffectInTime());
                StartCoroutine(ExecuteAfterTime(2f, () => { StopCoroutine(flickerCouroutine); Revival(); }));
                //Debug.Log("call stop");
                //StartCoroutine(ExecuteAfterTime(f, () => { Revival(); }));
                //Debug.Log("call reval");
            }
            else
            {
                Die();
                //Loader.LoadGameOver(); 
                gameOver.SetUp(Convert.ToInt32(textScore.text));
            }
        }
    }

    //private IEnumerator FlickerEffectInTime()
    //{
    //    while(true)
    //    {
    //        startTime += Time.deltaTime;
    //        if (startTime < 2)
    //        {
    //            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
    //            Debug.Log(startTime);
    //            yield return new WaitForSeconds(0.1f);
    //        }
    //        else
    //        {
    //            startTime = 0;
    //            GetComponent<SpriteRenderer>().enabled = true;
    //            Debug.Log("stoped flick");
    //            StopCoroutine("FlickerEffectInTime");
 
    //        }
    //    }
    //}
    private IEnumerator FlickerEffectInTime()
    {
        while(true)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void BackToOriginSpeed()
    {
        speed = originSpeed;
    }

    private void Die()
    {
        //chet
        AudioSource.PlayClipAtPoint(audioDie, Camera.main.transform.position, 1f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;

    }
    private void Revival()
    {
        //hoi sinh
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
    }


    private void Eat(float mass)
    {
        AudioSource.PlayClipAtPoint(audioEat, Camera.main.transform.position, 1f);
        //tang diem
        score += mass*mass * 100;
        textScore.text = score.ToString();
        //tang thanh process
        curentProcess.GetComponent<RectTransform>().localScale += new  Vector3(mass*0.3f, 0, 0);
        float currentProcessX = curentProcess.GetComponent<RectTransform>().localScale.x;
        //if (Mathf.Approximately(currentProcessX, 4f) )
        if (currentProcessX > 4f && isBigSize == false)
        {
            isBigSize = true;
            UpToBigSize();
        }
        else
        //if (Mathf.Approximately(currentProcessX, 2f))
        if (currentProcessX > 1f && isMediumSize == false)
        {
            isMediumSize = true;
            UpToMediumSize();
        }
        else
        if(currentProcessX >= 6)
        {
            WinThisScene();
            
        }
    }

    private void UpToMediumSize()
    {
        AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
        gameObject.transform.localScale = new Vector2(1.1f, 1.1f);
        mass += 0.5f;
    }

    private void UpToBigSize()
    {
        AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
        gameObject.transform.localScale = new Vector2(1.7f, 1.7f);
        mass += 0.5f;
    }

    private void WinThisScene()
    {
       gameWin.DisplayYouWin();
    }

    private void ScaleUp()
    {
        //tang khoi luong , tang kich thuoc
        AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
        this.transform.localScale = new Vector3(0.02f, 0.02f, 0f);
        mass += 0.5f;
    }

    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
    private void InCreaseLife()
    {
        AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
        int curentLife = Convert.ToInt32(textLife.text.Trim()) + 1;
        textLife.text = curentLife.ToString();
    }

    private void SpeedUpIn(float time)
    {
        AudioSource.PlayClipAtPoint(audioScaleUp, Camera.main.transform.position, 1f);
        speed *= 3;
        StartCoroutine(ExecuteAfterTime(time, () => { BackToOriginSpeed(); }));
    }
}
