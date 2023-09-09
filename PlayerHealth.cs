using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Image damageScreen;
    public bool checkDamageScreen = false;

    public static PlayerHealth instance;
    public Slider healthSilder;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        damageScreen.gameObject.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        healthSilder.value = hpPlayer;
        healthText.text = "HEALTH" + hpPlayer + "/100";
    }
    public IEnumerator delayDamageScreen()
    {
        checkDamageScreen = true;
        yield return new WaitForSeconds(0.5f);
        DamagePlayer(20);
        damageScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        damageScreen.gameObject.SetActive(false);
        checkDamageScreen = false;
    }
    public float hpPlayer = 100f;

    public void DamagePlayer(float damageAmount)
    {
        hpPlayer -= damageAmount;
    }
}
