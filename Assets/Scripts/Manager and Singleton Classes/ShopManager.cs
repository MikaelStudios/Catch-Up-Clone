using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

[System.Serializable]
public struct Ball 
{
    public string BallName;
    public Toggle toggle;
    public Material BallMaterial;
    public int Price;
}

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; }

    [SerializeField] private Ball[] balls;
    public LeanWindow Modal;
    public LeanWindow BrokeModal;
    string CurrentBall;

    private void Start()
    {
        //for (int i = 0; i < balls.Length; i++)
        //{
        //    PlayerPrefs.DeleteKey(balls[i].BallName);
        //}
    }
    public void Checker(GameObject ClickedObject) 
    {
        // if the dude is bought then dont toggle
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].BallName == ClickedObject.name) 
            {
                balls[i].toggle = ClickedObject.gameObject.GetComponentInChildren<Toggle>();
                if (PlayerPrefs.GetInt(balls[i].BallName) == 1)
                {
                    Debug.Log("A registered ball");
                    UpdatePlayer(balls[i].BallMaterial);
                }
                else 
                {
                        if (balls[i].toggle.isOn == true)
                        {
                            Debug.Log("the toggle is on");
                            Modal.TurnOn();
                            CurrentBall = balls[i].BallName;
                        }
                }
                break;
            }
        }
    }
    
    public void BuyBall()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].BallName == CurrentBall)
            {
              if (ScoreManager.ScoreInstance.Coins >= balls[i].Price)
                {
                    // spawn the ball;
                    ScoreManager.ScoreInstance.Coins -= balls[i].Price;
                    PlayerPrefs.SetInt("Coins", ScoreManager.ScoreInstance.Coins);
                    PlayerPrefs.SetInt(balls[i].BallName, 1);
                    PlayerPrefs.Save();
                    Debug.Log("You have bought the ball");
                    CurrentBall = "";
                    UpdatePlayer(balls[i].BallMaterial);
                }
                else 
                {
                    BrokeModal.TurnOn();
                    Debug.Log("Not enough cash to buy " + balls[i].Price);
                }
                break;
            }
        }
    }

    void UpdatePlayer(Material mat)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().material = mat;
    }

}
