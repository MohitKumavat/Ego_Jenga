using UnityEngine;

public class RightHandController : MonoBehaviour
{
    public Transform objToPickUp;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        float reach = animator.GetFloat("RightHand");
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, reach);
        animator.SetIKPosition(AvatarIKGoal.RightHand, objToPickUp.position);
    }
}