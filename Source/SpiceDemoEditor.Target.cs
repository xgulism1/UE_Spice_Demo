// Copyright (C) 2022-2025 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;

public class SpiceDemoEditorTarget : TargetRules
{
    public SpiceDemoEditorTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Editor;
        DefaultBuildSettings = BuildSettingsVersion.Latest;
        ExtraModuleNames.AddRange(new string[] { "SpiceDemo" });
    }
}
