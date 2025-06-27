using RimWorld;
using Verse;

namespace Rarr;

public class Building_TrapRat : Building_Trap
{
    private static readonly PawnKindDef rat = PawnKindDef.Named("Rat");

    protected override void SpringSub(Pawn p)
    {
        var faction = FactionUtility.DefaultFactionFrom(rat.defaultFactionDef);
        var pawn = GenSpawn.Spawn(PawnGenerator.GeneratePawn(rat, faction), Position, Map) as Pawn;
        pawn?.health.AddHediff(HediffDefOf.Scaria);
        pawn?.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
    }
}