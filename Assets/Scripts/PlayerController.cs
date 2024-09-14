using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveBall : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    private int count; //Observação (0): Variável Global
    //Devo mandar 
    public TextMeshProUGUI countText, winText;
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 3) //Observação (3): Consideramos 12 a quantidade de Pickups da cena!
            winText.text = "YOU WIN!!";
    }

    void OnTriggerEnter(Collider other)
    {
        SetCountText();
        if (other.gameObject.tag == "PickUp")
            other.gameObject.SetActive(false);
        count = count + 1;//Observação (2): Inserir depois de other.gameObject.SetActive(false);
    }
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }


    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);
    }
}