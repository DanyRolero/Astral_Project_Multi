public static class AstralRandom
{
    public static bool FlipCoin(float ratio = 0.5f)
    {
        Random random = new Random();
        return random.NextSingle() > ratio;
    }

    public static int IntRange(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max + 1);
    }
}