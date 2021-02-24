public class Level
{
    public float enemy1_rate;
    public float enemy2_rate;
    public float enemy3_rate;
    public int scoreToNextLevel;

    public Level(float e1_Rate, float e2_Rate, float e3_Rate, int maxScore)
    {
        enemy1_rate = e1_Rate;
        enemy2_rate = e2_Rate;
        enemy3_rate = e3_Rate;
        scoreToNextLevel = maxScore;
    }



}