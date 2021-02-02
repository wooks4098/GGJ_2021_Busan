using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Dog_Cat : MonoBehaviour
{

    // 스파인 애니메이션
    public SkeletonAnimation SkeletonAni;
    public AnimationReferenceAsset[] AnimClip;

    public enum AnimState { Idle, walk , Angry, sit};
    //현제 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState _AnimState;
    //현제 재생되고 있는 애니메이션
    private string CurrentAnimation;

    public float Speed;
    private Vector2 vector;

    Rigidbody2D rigid;
    private void Awake()
    {
        SkeletonAni = GetComponent<SkeletonAnimation>();
        rigid = GetComponent<Rigidbody2D>();
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
                _AsncAnimation(AnimClip[(int)AnimState.Idle], true, 1f);
                CurrentAnimation = "Dog, Cat_Idle";
                break;

            case AnimState.walk:
                _AsncAnimation(AnimClip[(int)AnimState.walk], true, 1f);
                CurrentAnimation = "Dog, Cat_Walk";
                break;
            case AnimState.Angry:
                _AsncAnimation(AnimClip[(int)AnimState.walk], true, 1f);
                CurrentAnimation = "Dog_Angry";
                break;
            case AnimState.sit:
                _AsncAnimation(AnimClip[(int)AnimState.walk], true, 1f);
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
