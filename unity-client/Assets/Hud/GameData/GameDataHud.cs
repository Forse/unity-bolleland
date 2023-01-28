using UnityEngine;
using UnityEngine.UI;

namespace Assets.Hud.GameData
{
    public class GameDataHud : MonoBehaviour
    {
        void Update() 
        {
            Debug.Log("Updating status in GameData Hud");

        }

        void Start() 
        {
            var status = GameState.Data.Status;
            var roundNumber = GameState.Data.RoundNumber;
            var text_Round = (Text)GetComponent("Text_Round");
            var text_Status = (Text)GetComponent("Text_Status");
            text_Status.text = status.ToString();
            Debug.Log("Setting status in GameData Hud");
        }
    }
}
