using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CatAnim : MonoBehaviour
{
    public Player player;

    // 스파인 애니메이션
    public SkeletonAnimation SkeletonAni;
    public AnimationReferenceAsset[] AnimClip;

    public enum AnimState { Idle, walk, Angry, sit };
    //현제 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;
    //현제 재생되고 있는 애니메이션
    private string CurrentAnimation;

    public float Speed;
    private double gapX;
    private double gapY;
    private int plusXstack, minusXstack = 0;
    private Vector2 bfPos;
    public bool isEatten;

    public Rigidbody2D rigid;
    private void Awake()
    {
        SkeletonAni = GetComponent<SkeletonAnimation>();
    }

    private void Start()
    {
        PlayerSkinChange("Cat_Idle");
        SetCurrentAnimation(AnimState.Idle);
        bfPos = transform.position;
        isEatten = false;
    }

    private void FixedUpdate()
    {
        GetVector();
        if (isEatten)
        {
            if ((gapX == 0) && (gapY == 0))
            {
                SetCurrentAnimation(AnimState.Idle);
            }
            else if (gapX > 0)
            {
                plusXstack += 1;
                minusXstack = 0;
                if (plusXstack >= 6)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    SetCurrentAnimation(AnimState.walk);
                }
            }
            else if (gapX < 0)
            {
                minusXstack += 1;
                plusXstack = 0;
                if (minusXstack >= 6)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    SetCurrentAnimation(AnimState.walk);
                }
            }
        }
    }

    private void GetVector()
    {
        gapX = (transform.position.x - bfPos.x) * 1000;
        gapY = (transform.position.y - bfPos.y) * 1000;
        bfPos.x = transform.position.x;
        bfPos.y = transform.position.y;
    }

    #region 스파인

    //스파인 애니메이션 변경
    //SetCurrentAnimation(AnimState.Idle);
    //SetCurrentAnimation(AnimState.walk);
    //SetCurrentAnimation(AnimState.Angry);
    //SetCurrentAnimation(AnimState.sit);
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
                _AsncAnimation(AnimClip[0], true, 1f);
                CurrentAnimation = "Dog, Cat_Idle";
                break;
            case AnimState.walk:
                _AsncAnimation(AnimClip[1], true, 1f);
                CurrentAnimation = "Dog, Cat_Walk";
                break;
            case AnimState.Angry:
                _AsncAnimation(AnimClip[2], true, 1f);
                CurrentAnimation = "Dog_Angry";
                break;
            case AnimState.sit:
                _AsncAnimation(AnimClip[3], true, 1f);
                CurrentAnimation = "Dog_Sit";
                break;
        }

    }

    //스킨변경
    void PlayerSkinChange(string Name)
    {
        //Cat_Idle
        //Dog_Angry
        //Dog_Idle
        //Dog_Sit
        SkeletonAni.skeleton.SetSkin(Name);
        SkeletonAni.skeleton.SetSlotsToSetupPose();
        SkeletonAni.AnimationState.Apply(SkeletonAni.skeleton);
    }
    #endregion
}
