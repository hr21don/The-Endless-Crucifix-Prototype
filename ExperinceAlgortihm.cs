public abstract class ExperinceAlgortihm
{
    public abstract int returnGoalEXP(int currentLevel);
}
public class LinearAlgortihm : ExperinceAlgortihm
{
    public readonly int LinearAmount = 100;
    public override int returnGoalEXP(int currentLevel)
    {
        return currentLevel = LinearAmount;
    }
}
