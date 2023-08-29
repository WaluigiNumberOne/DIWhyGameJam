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
        //5 ->  copy heart
        //6 ->  rechargeable heart

        public Sprite spr;
        public string sprString;

        private void Start()
        {
            base.Start();
            switch (heartType)
            {
                case 0:
                    sprString = "default";
                    break;
                case 1:
                    sprString = "speed";
                    break;
                case 2:
                    sprString = "jump";
                    break;
                case 3:
                    sprString = "metal";
                    break;
                case 4:
                    sprString = "bomb";
                    break;
                case 5:
                    sprString = "copy";
                    break;
                case 6:
                    sprString = "regen";
                    break;
                default:
                    break;
            }

            spr = Resources.Load<Sprite>(sprString);

            GetComponent<SpriteRenderer>().sprite = spr;
        }
        protected override void OnPicked(PlayerCharacterController player)
        {
            player.GetComponent<PlayerHeartManager>().AddHeart(heartType);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}