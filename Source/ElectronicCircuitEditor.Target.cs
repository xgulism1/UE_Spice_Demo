// Copyright (C) 2022-2024 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElectronicCircuitEditorTarget : TargetRules
{
	public ElectronicCircuitEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
        DefaultBuildSettings = BuildSettingsVersion.Latest;
        IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
        ExtraModuleNames.AddRange( new string[] { "ElectronicCircuit" } );
	}
}
