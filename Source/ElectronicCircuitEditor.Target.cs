// Copyright (C) 2022 Martin Gulis. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElectronicCircuitEditorTarget : TargetRules
{
	public ElectronicCircuitEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		DefaultBuildSettings = BuildSettingsVersion.V2;
		ExtraModuleNames.AddRange( new string[] { "ElectronicCircuit" } );
	}
}
