using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Hud.GameData
{
    public class GameDataHud : MonoBehaviour
    {
        private float nextActionTime = 0.0f;
        public float period = 1.0f;

        void Update() 
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                var status = GameState.Data.Status;
                var roundNumber = GameState.Data.RoundNumber;
                
                var textComponents = GetComponentsInChildren<Text>();
                var text_Round = textComponents.First(x => x.name == "Text_Round");
                var text_Status = textComponents.First(x => x.name == "Text_Status");

                text_Status.text = status.ToString();
                text_Round.text = "Round: " + roundNumber.ToString();
                Debug.Log("Updating status in GameData Hud");
            }

        }

        void Start() 
        {
            Debug.Log("Starting GameData Hud");
        }
    }
}
