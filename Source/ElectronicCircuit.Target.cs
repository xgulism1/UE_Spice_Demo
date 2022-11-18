// Copyright (C) 2022 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElectronicCircuitTarget : TargetRules
{
	public ElectronicCircuitTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_1;
		ExtraModuleNames.AddRange( new string[] { "ElectronicCircuit" } );
	}
}
