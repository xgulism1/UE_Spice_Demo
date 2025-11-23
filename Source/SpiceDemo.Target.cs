// Copyright (C) 2022-2025 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;

public class SpiceDemoTarget : TargetRules
{
    public SpiceDemoTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Game;
        DefaultBuildSettings = BuildSettingsVersion.Latest;
        IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
        ExtraModuleNames.AddRange(new string[] { "SpiceDemo" });
    }
}
