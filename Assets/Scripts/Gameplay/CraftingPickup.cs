using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class CraftingPickup : Pickup
    {
        //Duct Tape -> 0
        //Metal -> 1
        //Wire -> 2
        //Spring -> 3
        //Battery -> 4
        public int type;
        public int size;    //size of stack

        public Sprite spr;
        public string sprString;

        private void Start()
        {
            base.Start();
            switch (type)
            {
                case 0:
                    sprString = "tape";
                    break;
                case 1:
                    sprString = "metal";
                    break;
                case 2:
                    sprString = "wire";
                    break;
                case 3:
                    sprString = "spring";
                    break;
                case 4:
                    sprString = "battery";
                    break;
                default:
                    break;
            }

            spr = Resources.Load<Sprite>("Components/" + sprString);

            GetComponent<SpriteRenderer>().sprite = spr;
        }


        protected override void OnPicked(PlayerCharacterController player)
        {
            FindObjectOfType<CraftingManager>().add(type, size);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}