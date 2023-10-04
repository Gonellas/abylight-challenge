public enum RegisterType { car, character, building }

[System.Serializable]
public class Register
{
    public RegisterType type;
    public string comment;
    public int value;

    public string GetContent()
    {
        return type.ToString() + " [" + comment + "] " + value.ToString() + "\n";
    }
}