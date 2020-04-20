using System;

namespace NieRAutoIntelTracker
{
    [Flags]
    enum FishIntel
    {
        MACKEREL_MACHINE = 1,
        COELACANTH_MACHINE = 2,
        BREAM_MACHINE = 4,
        STARFISH_MACHINE = 8,
        SWORDFISH_MACHINE = 16,
        BLOWFISH_MACHINE = 32,
        BLOAT_FISH_MACHINE = 64,
        CARP_MACHINE = 128,

        ARAPAIMA_MACHINE = 1,
        KOI_CARP_MACHINE = 2,
        KILLIFISH_MACHINE = 4,
        BASKING_SHARK = 8,
        BREAM = 16,
        STARFISH = 32,
        BEETLE_FISH = 64,
        HORSESHOE_CRAB = 128,

        MACKEREL = 1,
        SWORDFISH = 2,
        BLOWFISH = 4,
        COELACANTH = 8,
        TWOFACE = 16,
        WATER_FLEA = 32,
        OIL_SARDINE = 64,
        ARAPAIMA = 128,

        FRESHWATER_RAY = 1,
        FUR_CARP = 2,
        KOI_CARP = 4,
        BLOAT_FISH = 8,
        CARP = 16,
        KILLIFISH = 32,
        TWINFISH = 64,
        AROWANA = 128,

        //POD_B = 64,
        BROKEN_FIREARM = 128,

        BATTERY = 1,
        GAS_CYLINDER = 2,
        TIRE = 4,
        MACHINE_LIFEFORM_HEAD = 8,
        FRESHWATER_RAY_MACHINE = 16,
        BASKING_SHARK_MACHINE = 32,
        AROWANA_MACHINE = 64,
        HORSESHOE_CRAB_MACHINE = 128,
    }
}
