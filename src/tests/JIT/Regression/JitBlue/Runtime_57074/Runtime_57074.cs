// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Generated by Fuzzlyn v1.2 on 2021-08-06 13:43:59
// Run on .NET 6.0.0-dev on X64 Windows
// Seed: 4503995795470420928
// Reduced from 174.4 KiB to 1.0 KiB in 00:01:45
// Debug: Outputs 0
// Release: Outputs 1
using System.Runtime.CompilerServices;

public class Program
{
    static bool s_5 = true;
    static uint[] s_8;
    static uint s_9 = 1;
    static long s_13;
    static uint s_15;
    public static int Main()
    {
        s_5 = s_5; // Make sure we get no static helpers in function below
        M49();
        return s_9 == 0 ? 100 : -1;
    }

    // Redundant branch opts would optimize BB03 -> BB05 to go BB03 -> BB06.
    // After this, the dominator of BB06 changes to BB02, but when we processed
    // it we still saw BB05. This caused us to follow up by changing BB03 -> BB08.
    static void M49()
    {
        for (int var0 = 0; var0 < Bound(); var0++)
        {
            // BB02
            long var1 = 0;
            if (s_5)
            {
                // BB03
                var1 = s_13;
            }
            else
            {
                // BB04
                s_8[0] = 0;
            }

            // BB05
            if (s_5)
            {
                // BB06
                if (s_5)
                {
                    // BB07
                    s_9 = 0;
                }

                // BB08
                long var2 = var1;
                return;
            }
            else
            {
                try
                {
                    s_8[0] = s_9;
                }
                finally
                {
                    var1 = 0;
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int Bound() => 1;
}
