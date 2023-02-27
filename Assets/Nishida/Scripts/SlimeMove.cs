using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    //Rigidbody型のrbという変数を作る
    private Rigidbody rb;
    public Transform tf_target;
    public string target;
    public float damping, speed, yOffset;
    private int hp = 100;
    private bool isAttack, isDead = false;
    private Animator animator;
    public ParticleSystem attackExplosion, deathExplosion;
    public GameObject ikura, hit, expInkGreen, expInkPink;


    private void Start()
    {
        //リジットボディを取得しrbに代入する
        rb = GetComponent<Rigidbody>();
        //爆発アニメーションを登録する
        animator = this.GetComponent<Animator>();
        tf_target = GameObject.Find(target).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0 && !isDead)
        {
            explosion();
            isDead = true;
        }

        var lookPos = tf_target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

        //rbの回転をさせない様にする
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= 35;
            hit.GetComponents<AudioSource>()[0].enabled = true;
            hit.GetComponents<AudioSource>()[1].enabled = false;
            Instantiate(hit, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.speed = 0;
            isAttack = true;
            animator.SetBool("death", true);
        }
    }

    private void death()
    {
        animator.SetBool("death", true);
    }
    //爆発アニメーション用　爆発エフェクトを生成しながら消え、地面を大きく塗る　攻撃の場合緑、死亡の場合ピンク
    public void explosion()
    {


        if (isAttack)
        {
            //爆発エフェクト（緑）再生
            Instantiate(attackExplosion, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
            //地面塗りオブジェクト（兼攻撃判定）を出す
        }
        else
        {
            //爆発エフェクト（ピンク）再生
            Instantiate(deathExplosion, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
            //いくらを出す
            for (int i = 0; i < 3; i++)
            {
                GameObject ikuras = Instantiate(ikura, transform.position + new Vector3(-1f * i * 0.2f, yOffset, -1f * i * 0.2f), Quaternion.identity);
            }
        }


        //当たり判定を削除しモデルを非表示にする
        GetComponent<SphereCollider>().enabled = false;
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        //1秒後に自身を破壊
        Invoke("destroy", 0.1f);
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }


}
