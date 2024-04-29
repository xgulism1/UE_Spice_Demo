// Copyright (C) 2022-2024 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElectronicCircuitTarget : TargetRules
{
	public ElectronicCircuitTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		ExtraModuleNames.AddRange( new string[] { "ElectronicCircuit" } );
	}
}
