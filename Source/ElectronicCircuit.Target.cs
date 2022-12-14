// Copyright (C) 2022 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElectronicCircuitTarget : TargetRules
{
	public ElectronicCircuitTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "ElectronicCircuit" } );
	}
}
