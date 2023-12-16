

public class ResAccountDetails
{
    public ResAccountDetails(string username, string password, int score, string positionX, string positionY, string positionZ, int otp)
    {
        this.username = username;
        this.password = password;
        this.score = score;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
        this.otp = otp;
    }

    public string username { get; set; }
    public string password { get; set; }
    public int score { get; set; }
    public string positionX { get; set; }
    public string positionY { get; set; }
    public string positionZ { get; set; }
    public int otp { get; set; }
}