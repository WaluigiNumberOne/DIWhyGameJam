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

        protected override void OnPicked(PlayerCharacterController player)
        {
            FindObjectOfType<CraftingManager>().add(type, size);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}