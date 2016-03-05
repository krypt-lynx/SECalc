using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECalc.Data // I hate MS Xml serializer, said it before?
{
    public class MyObjectBuilder_BatteryBlockDefinition : Block { }
    public class MyObjectBuilder_ProgrammableBlockDefinition : Block { }
    public class MyObjectBuilder_LargeTurretBaseDefinition : Block { }
    public class MyObjectBuilder_DoorDefinition : Block { }
    public class MyObjectBuilder_RadioAntennaDefinition : Block { }
    public class MyObjectBuilder_BeaconDefinition : Block { }
    public class MyObjectBuilder_ReflectorBlockDefinition : Block { }
    public class MyObjectBuilder_LightingBlockDefinition : Block { }
    public class MyObjectBuilder_WarheadDefinition : Block { }
    public class MyObjectBuilder_LandingGearDefinition : Block { }
    public class MyObjectBuilder_ProjectorDefinition : Block { }
    public class MyObjectBuilder_RefineryDefinition : Block { }
    public class MyObjectBuilder_OxygenGeneratorDefinition : Block { }
    public class MyObjectBuilder_AssemblerDefinition : Block { }
    public class MyObjectBuilder_OreDetectorDefinition : Block { }
    public class MyObjectBuilder_MedicalRoomDefinition : Block { }
    public class MyObjectBuilder_GravityGeneratorDefinition : Block { }
    public class MyObjectBuilder_GravityGeneratorSphereDefinition : Block { }
    public class MyObjectBuilder_JumpDriveDefinition : Block { }
    public class MyObjectBuilder_CockpitDefinition : Block { }
    public class MyObjectBuilder_CryoChamberDefinition : Block { }
    public class MyObjectBuilder_WeaponBlockDefinition : Block { }
    public class MyObjectBuilder_ShipDrillDefinition : Block { }
    public class MyObjectBuilder_SensorBlockDefinition : Block { }
    public class MyObjectBuilder_SoundBlockDefinition : Block { }
    public class MyObjectBuilder_TextPanelDefinition : Block { }
    public class MyObjectBuilder_GasTankDefinition : Block { }
    public class MyObjectBuilder_RemoteControlDefinition : Block { }
    public class MyObjectBuilder_AirVentDefinition : Block { }
    public class MyObjectBuilder_UpgradeModuleDefinition : Block { }
    public class MyObjectBuilder_CargoContainerDefinition : Block { }
    public class MyObjectBuilder_ThrustDefinition : Block { }
    public class MyObjectBuilder_CameraBlockDefinition : Block { }
    public class MyObjectBuilder_GyroDefinition : Block { }
    public class MyObjectBuilder_ReactorDefinition : Block { }
    public class MyObjectBuilder_PistonBaseDefinition : Block { }
    public class MyObjectBuilder_ExtendedPistonBaseDefinition : Block { }
    public class MyObjectBuilder_MotorStatorDefinition : Block { }
    public class MyObjectBuilder_MotorSuspensionDefinition : Block { }
    public class MyObjectBuilder_MotorAdvancedStatorDefinition : Block { }
    public class MyObjectBuilder_ButtonPanelDefinition : Block { }
    public class MyObjectBuilder_TimerBlockDefinition : Block { }
    public class MyObjectBuilder_SolarPanelDefinition : Block { }
    public class MyObjectBuilder_OxygenFarmDefinition : Block { }
    public class MyObjectBuilder_PoweredCargoContainerDefinition : Block { }
    public class MyObjectBuilder_ConveyorSorterDefinition : Block { }
    public class MyObjectBuilder_VirtualMassDefinition : Block { }
    public class MyObjectBuilder_SpaceBallDefinition : Block { }
    public class MyObjectBuilder_MergeBlockDefinition : Block { }
    public class MyObjectBuilder_LaserAntennaDefinition : Block { }
    public class MyObjectBuilder_AirtightHangarDoorDefinition : Block { }
    public class MyObjectBuilder_AirtightSlideDoorDefinition : Block { }
    public class MyObjectBuilder_DebugSphere1Definition : Block { }
    public class MyObjectBuilder_DebugSphere2Definition : Block { }
    public class MyObjectBuilder_DebugSphere3Definition : Block { }

    partial class BlocksFile
    {
        static Type[] GetBlockTypes()
        {
            return new Type[]
            {
                typeof( MyObjectBuilder_BatteryBlockDefinition  ),
                typeof( MyObjectBuilder_ProgrammableBlockDefinition ),
                typeof( MyObjectBuilder_LargeTurretBaseDefinition   ),
                typeof( MyObjectBuilder_DoorDefinition  ),
                typeof( MyObjectBuilder_RadioAntennaDefinition  ),
                typeof( MyObjectBuilder_BeaconDefinition    ),
                typeof( MyObjectBuilder_ReflectorBlockDefinition    ),
                typeof( MyObjectBuilder_LightingBlockDefinition ),
                typeof( MyObjectBuilder_WarheadDefinition   ),
                typeof( MyObjectBuilder_LandingGearDefinition   ),
                typeof( MyObjectBuilder_ProjectorDefinition ),
                typeof( MyObjectBuilder_RefineryDefinition  ),
                typeof( MyObjectBuilder_OxygenGeneratorDefinition   ),
                typeof( MyObjectBuilder_AssemblerDefinition ),
                typeof( MyObjectBuilder_OreDetectorDefinition   ),
                typeof( MyObjectBuilder_MedicalRoomDefinition   ),
                typeof( MyObjectBuilder_GravityGeneratorDefinition  ),
                typeof( MyObjectBuilder_GravityGeneratorSphereDefinition    ),
                typeof( MyObjectBuilder_JumpDriveDefinition ),
                typeof( MyObjectBuilder_CockpitDefinition   ),
                typeof( MyObjectBuilder_CryoChamberDefinition   ),
                typeof( MyObjectBuilder_ReflectorBlockDefinition    ),
                typeof( MyObjectBuilder_WeaponBlockDefinition   ),
                typeof( MyObjectBuilder_ShipDrillDefinition ),
                typeof( MyObjectBuilder_SensorBlockDefinition   ),
                typeof( MyObjectBuilder_SoundBlockDefinition    ),
                typeof( MyObjectBuilder_TextPanelDefinition ),
                typeof( MyObjectBuilder_GasTankDefinition   ),
                typeof( MyObjectBuilder_OxygenGeneratorDefinition   ),
                typeof( MyObjectBuilder_RadioAntennaDefinition  ),
                typeof( MyObjectBuilder_RemoteControlDefinition ),
                typeof( MyObjectBuilder_AirVentDefinition   ),
                typeof( MyObjectBuilder_UpgradeModuleDefinition ),
                typeof( MyObjectBuilder_CargoContainerDefinition    ),
                typeof( MyObjectBuilder_ThrustDefinition    ),
                typeof( MyObjectBuilder_CameraBlockDefinition   ),
                typeof( MyObjectBuilder_GyroDefinition  ),
                typeof( MyObjectBuilder_ReactorDefinition   ),
                typeof( MyObjectBuilder_PistonBaseDefinition    ),
                typeof( MyObjectBuilder_ExtendedPistonBaseDefinition    ),
                typeof( MyObjectBuilder_MotorStatorDefinition   ),
                typeof( MyObjectBuilder_MotorSuspensionDefinition   ),
                typeof( MyObjectBuilder_MotorAdvancedStatorDefinition   ),
                typeof( MyObjectBuilder_ButtonPanelDefinition   ),
                typeof( MyObjectBuilder_TimerBlockDefinition    ),
                typeof( MyObjectBuilder_SolarPanelDefinition    ),
                typeof( MyObjectBuilder_OxygenFarmDefinition    ),
                typeof( MyObjectBuilder_PoweredCargoContainerDefinition ),
                typeof( MyObjectBuilder_ConveyorSorterDefinition    ),
                typeof( MyObjectBuilder_VirtualMassDefinition   ),
                typeof( MyObjectBuilder_SpaceBallDefinition ),
                typeof( MyObjectBuilder_MergeBlockDefinition    ),
                typeof( MyObjectBuilder_ProgrammableBlockDefinition ),
                typeof( MyObjectBuilder_LaserAntennaDefinition  ),
                typeof( MyObjectBuilder_AirtightHangarDoorDefinition    ),
                typeof( MyObjectBuilder_AirtightSlideDoorDefinition ),
                typeof( MyObjectBuilder_DebugSphere1Definition  ),
                typeof( MyObjectBuilder_DebugSphere2Definition  ),
                typeof( MyObjectBuilder_DebugSphere3Definition  )
            };
        }
    }

}
