using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class HeartsUI : MonoBehaviour
    {
        private PlayerHeartManager m_PlayerHearts;
        private List<Image> heartSlots;

        float activeHeartSize = 1f;
        float heartScalingTime = 0f;
        float MAX_SCALE_TIME = 2;

        // Start is called before the first frame update
        void Start()
        {
            // Subscribe to player damage events
            PlayerCharacterController playerCharacterController = FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, FeedbackFlashHUD>(
                playerCharacterController, this);

            m_PlayerHearts = playerCharacterController.GetComponent<PlayerHeartManager>();
            DebugUtility.HandleErrorIfNullGetComponent<PlayerHeartManager, FeedbackFlashHUD>(m_PlayerHearts, this,
                playerCharacterController.gameObject);

            heartSlots = transform.GetComponentsInChildren<Image>().ToList();
            heartSlots.RemoveAt(0); // get rid of parent
                                    // no but seriously why does the "get components IN CHILDREN" also return the parent
        }

        // Update is called once per frame
        void Update()
        {
            if(m_PlayerHearts.healthChanged)
            {
                UpdateHeartUI();
                m_PlayerHearts.healthChanged = false;
            }


            //Scale Active Heart
            heartScalingTime += Time.deltaTime;

            // 0-1
            if(heartScalingTime < MAX_SCALE_TIME/2)
            {
                activeHeartSize = 1 + .25f * heartScalingTime;
            }
            //1-2
            else if(heartScalingTime > MAX_SCALE_TIME/2 && heartScalingTime < MAX_SCALE_TIME)
            {
                activeHeartSize = 1.25f - (.25f * (heartScalingTime - 1));
            }
            //RESET
            else if(heartScalingTime > MAX_SCALE_TIME)
            {
                heartScalingTime = 0;
            }
            heartSlots[m_PlayerHearts.hearts.Count - 1].rectTransform.localScale = Vector2.one * activeHeartSize;
        }

        public void UpdateHeartUI()
        {
           for(int i = 0; i < m_PlayerHearts.hearts.Count; i++)
            {
                Sprite img = m_PlayerHearts.hearts[i].spr;
                if(!img)
                {
                    Debug.Log("No sprite found for: " + m_PlayerHearts.hearts[i]);
                }
                heartSlots[i].sprite = img;
                heartSlots[i].color = Color.white;

                //Debug.Log("hearts updated");
            }

           //set other slots to clear
           for(int j = m_PlayerHearts.hearts.Count; j < heartSlots.Count ; j++)
            {
                heartSlots[j].color = Color.clear;
            }
        }
    }
}
