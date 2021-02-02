using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{

    // 스파인 애니메이션
    public SkeletonAnimation SkeletonAni;
    public AnimationReferenceAsset[] AnimClip;

    public enum AnimState { Idle, walk};
    //현제 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;
    //현제 재생되고 있는 애니메이션
    private string CurrentAnimation;


    public AudioSource source;
    public AudioClip clip;
    public float Speed;
    private Vector2 vector;
    bool isMove;

    Rigidbody2D rigid;
    private void Awake()
    {
        SkeletonAni = GetComponent<SkeletonAnimation>();
        rigid = GetComponent<Rigidbody2D>();
        //source = GetComponent<AudioSource>();
        isMove = false;
        //source.clip = clip;
    }



    private void FixedUpdate()
    {
           Move();
        if (isMove)
        {
            //if (!source.isPlaying)
                //source.Play();
                //SoundManager.instance.SoundPlay("Player_Walk");

        }
        else {
            //source.Stop();
        }

    }
    void Update()
    {
        
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.A))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        rigid.velocity = vector.normalized * Speed;

        if (rigid.velocity.x == 0 && rigid.velocity.y == 0)
        {
            SetCurrentAnimation(AnimState.Idle);
            isMove = false;

        }

        else
        {
            SetCurrentAnimation(AnimState.walk);
            isMove = true;

        }



        #region transfrom이동
        //if (Input.GetKey(KeyCode.A))
        //{
        //    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
        //    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
        //}
        #endregion
    }

    //스파인 애니메이션 변경
    void _AsncAnimation(AnimationReferenceAsset animClip, bool loop, float timeScale)
    {
        //애니매이션이 사용중이면 리턴
        if (animClip.name.Equals(CurrentAnimation))
            return;

        //해당 애니메이션으로 변경한다
        SkeletonAni.state.SetAnimation(0, animClip, loop).TimeScale = timeScale;
        SkeletonAni.loop = loop;
        SkeletonAni.timeScale = timeScale;
    }

    //상태에 따른 애니매이션 선택
    void SetCurrentAnimation(AnimState _state)
    {
        switch (_state)
        {
            case AnimState.Idle:
                _AsncAnimation(AnimClip[(int)AnimState.Idle], true, 1f);
                CurrentAnimation = "Idle";
                break;

            case AnimState.walk:
                _AsncAnimation(AnimClip[(int)AnimState.walk], true, 1.2f);
                CurrentAnimation = "walk";
                break;

        }

    }

    public void PlayerSkinChange()
    {
        //플래시 라이트를 든 스킨으로 변경
        SkeletonAni.skeleton.SetSkin("flashlight");
        SkeletonAni.skeleton.SetSlotsToSetupPose();
        SkeletonAni.AnimationState.Apply(SkeletonAni.skeleton);
    }

}
