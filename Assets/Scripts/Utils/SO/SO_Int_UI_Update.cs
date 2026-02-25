using TMPro;
using UnityEngine;

public class SO_Int_UI_Update : MonoBehaviour
{
    public SO_Int so_Int;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        uiTextValue.text = so_Int.value.ToString();
    }

    private void Update()
    {
        uiTextValue.text = so_Int.value.ToString();
    }
}
