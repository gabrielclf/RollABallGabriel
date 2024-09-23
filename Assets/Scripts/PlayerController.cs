using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveBall : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    private int count;
    private int winCon = 15;
    //Devo mandar 
    public TextMeshProUGUI countText, winText;

    public Reset reiniciar;
    void SetCountText()
    {
        countText.text = "Cubos: " + count.ToString()+"/"+winCon;
        if (count >= winCon) { //Observação (3): Consideramos 12 a quantidade de Pickups da cena!
            winText.text = "YOU WIN!!";
            reiniciar.GameReset();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SetCountText();
        if (other.gameObject.tag == "PickUp")
            other.gameObject.SetActive(false);
        count++;//Observação (2): Inserir depois de other.gameObject.SetActive(false);
    }
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        winText.text = "";
    }


    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);
        SetCountText();
    }
}