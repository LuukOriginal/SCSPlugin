# SCS Plugin for Macro Deck 2
<img alt="Macro Deck 2 Community Plugin" height="64px" align="center" src="https://macrodeck.org/images/macro_deck_2_community_plugin.png"/>

---
*This is a plugin for Macro Deck 2 and does **not** function as a standalone app.*

## Table of Contents
- [Overview](#overview)
- [Installation](#installation)
- [Features](#features)
- [Requesting New Variables](#requesting-new-variables)
- [Third-Party Licenses](#third-party-licenses)

## Overview
The **SCS Plugin** for Macro Deck 2 automatically syncs and updates telemetry data variables from **Euro Truck Simulator 2 (ETS2)** and **American Truck Simulator (ATS)**, providing real-time variables on Macro Deck.

## Installation
1. Go to the [releases page](https://github.com/LuukOriginal/SCSPlugin/releases/) and download the latest `Release.zip`.
2. Unzip the `Release.zip` file.
3. Exit the Macro Deck application:
   - Locate the Macro Deck icon in the system tray, right-click on it, and select **Exit Macro Deck**.
4. Copy the `LuukOriginal.SCSPlugin` folder to `%appdata%/Macro Deck/plugins`.
5. Place the appropriate DLL from the `telemetry` folder into your ETS2/ATS installation:
   - **64-bit**: Copy the DLL from the `Win64` folder to `bin/win_x64/plugins/`.
   - **32-bit**: Copy the DLL from the `Win32` folder to `bin/win_x32/plugins/`.
   - **Note**: If the `plugins` directory does not exist, create it and then place the DLLs inside.
6. Restart Macro Deck and check the **Plugins** section to verify that the **SCS Plugin** is loaded successfully.

**Important**: Each time ETS2/ATS starts, a prompt will appear stating that the SDK has been activated. Unfortunately, there is no way to disable this prompt, so you will need to click **OK** each time.

## Features
Currently, the plugin supports the following telemetry variables:

### Lights:
- `Lights_BeamLow_On`
- `Lights_BeamHigh_On`
- `Lights_Beacon_On`
- `Lights_HazardLights_On`
- `Lights_LeftBlinker_On`
- `Lights_RightBlinker_On`

### Navigation:
- `Navigation_NavigationTime`
- `Navigation_NavigationDistance`
- `Navigation_SpeedLimit_KMH`
- `Navigation_SpeedLimit_MPH`

### Dashboard:
- `Dashboard_Wipers_On`
- `Dashboard_ParkingBrake`
- `Dashboard_AirPressure`
- `Dashboard_AirPressure_Emergency`
- `Dashboard_Speed_KMH`
- `Dashboard_Speed_MPH`

### Motor:
- `Motor_EngineEnabled`

### Fuel:
- `Fuel_FuelAmount`
- `Fuel_FuelRange`
- `Fuel_FuelAverageConsumption`
- `Fuel_FuelWarning`

### Trailer:
- `Trailer_Attached`

### Job:
- `Job_CityDestination`
- `Job_CompanyDestination`
- `Job_CitySource`
- `Job_CompanySource`
- `Job_Payout`
- `Job_CargoName`
- `Job_CargoLoaded`
- `Job_PlannedDistance_KM`
- `Job_DeliveryTime`
- `Job_RemainingDeliveryTime`

## Requesting New Variables
If you need additional variables, please create an issue with the **feature request** label. **Note**: The requested variable must be part of the SCS Telemetry. You can refer to the complete list of available variables in the [README](https://github.com/RenCloud/scs-sdk-plugin) of the SCS SDK Plugin repository.

## Third-Party Licenses
This plugin makes use of:
- [Macro Deck 2 by SuchByte (Apache License 2.0)](https://macrodeck.org)
- [SCS SDK Plugin (MIT License)](https://github.com/RenCloud/scs-sdk-plugin)
