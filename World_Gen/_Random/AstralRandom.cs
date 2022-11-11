public static class AstralRandom
{
    public static bool FlipCoin(float ratio = 0.5f)
    {
        Random random = new Random();
        return random.NextSingle() > ratio;
    }
}


