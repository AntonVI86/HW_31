using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _loadingCircle;
    [SerializeField] private TMP_Text _message;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void ShowMessage(string message) => _message.text = message;
    private void Update()
    {
        _loadingCircle.transform.Rotate(Vector3.forward * Time.deltaTime * 100f, Space.World);
    }
}
