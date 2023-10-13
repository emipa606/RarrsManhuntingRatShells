using RimWorld;
using Verse;

namespace Rarr;

public class Projectile_ManhuntingRatShell : Bullet
{
    private static readonly PawnKindDef rat = PawnKindDef.Named("Rat");

    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        var faction = FactionUtility.DefaultFactionFrom(rat.defaultFactionType);
        // Spawns 5 rats
        for (var i = 0; i < 5; i++)
        {
            var pawn = GenSpawn.Spawn(PawnGenerator.GeneratePawn(rat, faction), Position, Map) as Pawn;
            pawn?.health.AddHediff(HediffDefOf.Scaria);
            pawn?.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
        }

        GenClamor.DoClamor(this, 2.1f, ClamorDefOf.Impact);
        Destroy();
    }
}