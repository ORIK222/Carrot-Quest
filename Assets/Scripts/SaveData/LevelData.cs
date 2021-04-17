using System;

[Serializable]
public class LevelData
{
    public int[] LevelStarCount;
    
    public LevelData()
    {
        LevelStarCount = new int[40];
        for (int i = 0; i < 31; i++)
        {
            LevelStarCount[i] = 0;
        }
    }
}
