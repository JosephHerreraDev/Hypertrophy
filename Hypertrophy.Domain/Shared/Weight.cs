namespace Hypertrophy.Domain.Shared;

public readonly record struct Weight(
    float Amount,
    eWeightUnit Unit
)
{
    private const float LbToKg = 0.45359237f;
    private const float KgToLb = 1f / LbToKg;

    public float InKg =>
        Unit == eWeightUnit.Kg
            ? Amount
            : Amount * LbToKg;

    public float InLb =>
        Unit == eWeightUnit.Lb
            ? Amount
            : Amount * KgToLb;

    public Weight ToKg() =>
        new(InKg, eWeightUnit.Kg);

    public Weight ToLb() =>
        new(InLb, eWeightUnit.Lb);

    public override string ToString() =>
        $"{Amount:0.##} {Unit}";
}
