using UnityEngine;
[System.Serializable]
public struct MaterialAnimated
{
    public Material TheMaterial;
    public Color colorA;
    public Color colorB;
    public Color colorC;
    public Color colorD;
}
public class ColorAnimation : MonoBehaviour
{
    [SerializeField] MaterialAnimated[] Materials;
    float Timer;
    float Timer2;
    float _Time;
    private void Start()
    {
        Timer = Random.Range(3, 5);
        Timer2 = Random.Range(3, 5) + Timer;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _Time += Time.deltaTime;
        for (int i = 0; i < Materials.Length; i++)
        {
            if (_Time < Timer)
            {
                Color color = Color.Lerp(Materials[i].colorA, Materials[i].colorB, Mathf.PingPong(Time.time * Random.Range(3, 4), 1));
                Materials[i].TheMaterial.color = color;
            }
            else if (_Time > Timer)
            {

                Color color = Color.Lerp(Materials[i].colorC, Materials[i].colorD, Mathf.PingPong(Time.time * Random.Range(2, 4), 1));
                Materials[i].TheMaterial.color = color;
                if (_Time >= Timer2)
                {
                    _Time = 0;
                }
            }
            
        }
    }
}
