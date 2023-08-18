using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class HealthPickup : Pickup
    {
        public int heartType;


        //0 ->  default heart
        //1 ->  speed heart
        //2 ->  jump heart
        //3 ->  metal heart
        //4 ->  bomb heart

        protected override void OnPicked(PlayerCharacterController player)
        {
            player.GetComponent<PlayerHeartManager>().AddHeart(heartType);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}