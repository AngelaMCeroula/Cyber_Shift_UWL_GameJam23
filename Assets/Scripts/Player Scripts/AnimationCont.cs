using UnityEngine;

namespace Player_Scripts
{
    public class AnimationCont : MonoBehaviour
    {
        public Animator ani;
    
        public void SetAnimation(string animationName)
        {
        
            //call function as SetAnimation(string animationName)
        
            switch (animationName)
            {
                case "IsShot":
                    ani.ResetTrigger("IsIdle");
                    ani.ResetTrigger("IsRunning");
                    ani.ResetTrigger("IsJumping");
                    ani.SetTrigger(animationName);
                    break;
                case "IsRunning":
                    ani.ResetTrigger("IsIdle");
                    ani.ResetTrigger("IsShot");
                    ani.ResetTrigger("IsJumping");
                    ani.SetTrigger(animationName);
                    break;
                case "IsIdle":
                    ani.ResetTrigger("IsShot");
                    ani.ResetTrigger("IsRunning");
                    ani.ResetTrigger("IsJumping");
                    ani.SetTrigger(animationName);
                    break;
                case "IsJumping":
                    ani.ResetTrigger("IsShot");
                    ani.ResetTrigger("IsRunning");
                    ani.ResetTrigger("IsIdle");
                    ani.SetTrigger(animationName);
                    break;
            }
        }
    }
}
