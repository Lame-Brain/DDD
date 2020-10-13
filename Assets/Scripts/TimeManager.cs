using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static string HOUR = "", DAY = "", MONTH = "";
    public static float HOUR_FLOAT;
    public static int DAY_INT = 1, MONTH_INT = 0, YEAR_INT = -4;

    public static void AdvanceTime(float v)
    {
        HOUR_FLOAT += v;

        //Display Time, Day, and Month correctly.
        //        if (Math.Round(HOUR_FLOAT, 0, MidpointRounding.AwayFromZero) > 4 && Math.Round(HOUR_FLOAT, 0, MidpointRounding.AwayFromZero) < 6) HOUR = "<color=cyan>Afternoon</color> ";

        if (HOUR_FLOAT > 12) { HOUR_FLOAT = 0; DAY_INT++; }
        if (HOUR_FLOAT < 1) HOUR = "<color=blue>Sunrise</color> ";
        if (HOUR_FLOAT >= 1 && HOUR_FLOAT <= 3) HOUR = "<color=yellow>Morning</color> ";
        if (HOUR_FLOAT > 3 && HOUR_FLOAT < 4) HOUR = "<color=blue>Noon</color> ";
        if (HOUR_FLOAT >= 4 && HOUR_FLOAT <= 6) HOUR = "<color=cyan>Afternoon</color> ";
        if (HOUR_FLOAT > 6 && HOUR_FLOAT < 7) HOUR = "<color=magenta>Sunset</color> ";
        if (HOUR_FLOAT >= 7 && HOUR_FLOAT <= 9) HOUR = "<color=teal>Early Night</color> ";
        if (HOUR_FLOAT > 9 && HOUR_FLOAT < 10) HOUR = "<color=black>Midnight</color> ";
        if (HOUR_FLOAT >= 10 && HOUR_FLOAT <= 12) HOUR = "<color=darkblue>Late Night</color> ";

        if (MONTH_INT == 0)            
        {
            MONTH = "";
            if (DAY_INT > 1) AdvanceMonth();
        }
        if (MONTH_INT == 1)
        {
            MONTH = "<color=magenta>Holy to GREAT MOTHER</color>";
            if (DAY_INT > 4) AdvanceMonth();
        }
        if (MONTH_INT == 2)
        {
            MONTH = "of the <color=white>Month of UL</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 3)
        {
            MONTH = "of the <color=white>Month of NIOTL</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 4)
        {
            MONTH = "of the <color=white>Month of OZTOZ</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 5)
        {
            MONTH = "of <color=magenta>the Spring Equinox</color>";
            if (DAY_INT > 7) AdvanceMonth();
        }
        if (MONTH_INT == 6)
        {
            MONTH = "of the <color=lime>Month of FOTA</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 7)
        {
            MONTH = "of the <color=lime>Month of ADAR</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 8)
        {
            MONTH = "of the <color=lime>Month of VIUNA</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 9)
        {
            MONTH = "of <color=magenta>the Summer Solstice</color>";
            if (DAY_INT > 6) AdvanceMonth();
        }
        if (MONTH_INT == 10)
        {
            MONTH = "of the <color=yellow>Month of IAMUS</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 11)
        {
            MONTH = "of the <color=yellow>Month of SAMDIOME</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 12)
        {
            MONTH = "of the <color=yellow>Month of ELIUS</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 13)
        {
            MONTH = "of <color=magenta>the Autumn Equinox</color>";
            if (DAY_INT > 7) AdvanceMonth();
        }
        if (MONTH_INT == 14)
        {
            MONTH = "of the <color=brown>Month ZEDIA</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 15)
        {
            MONTH = "of the <color=brown>Month of YNARUS</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 16)
        {
            MONTH = "of the <color=brown>Month of RANERA</color>";
            if (DAY_INT > 28) AdvanceMonth();
        }
        if (MONTH_INT == 17)
        {
            MONTH = "<color=magenta>Holy to the WISE CRONE</color>";
            if (DAY_INT > 4) AdvanceMonth();
        }

        DAY = "the " + DAY_INT + "th day ";
        if (DAY_INT == 1) DAY = "the 1st day ";
        if (DAY_INT == 2) DAY = "the 2nd day ";
        if (DAY_INT == 3) DAY = "the 3rd day ";
        if (DAY_INT == 21) DAY = "the 21st day ";
        if (DAY_INT == 22) DAY = "the 22nd day ";
        if (DAY_INT == 23) DAY = "the 23rd day ";
        if (MONTH_INT == 0) DAY = "of the <color=white>THE WINTER SOLSTICE</color> ";
    }

    private static void AdvanceMonth()
    {
        DAY_INT = 1;
        MONTH_INT++;
        if (MONTH_INT > 17) { MONTH_INT = 0; YEAR_INT++; }
    }
}
