using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    private void Start()
    {
        Field field = new Field();

        field.SetStartRoom();
        field.SetExitRoom();
        field.ShowMainPath();
    }
}
