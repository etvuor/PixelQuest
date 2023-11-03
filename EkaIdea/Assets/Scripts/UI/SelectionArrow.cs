using UnityEngine.UI;
using UnityEngine;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;


    private void Awake()
    {
           rect = GetComponent<RectTransform>();  
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.S)  || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Interact();
        }
    }
    private void ChangePosition (int _change)
    {
        currentPosition += _change;
        if (currentPosition < 0)
        {
            currentPosition = options.Length - 1;
        }
        else if (currentPosition > options.Length -1)
        {
            currentPosition = 0;
        }

        
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y + 20, 0);
    }

    public void Interact()
    {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }

}
