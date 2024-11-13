using SCSSdkClient;
using SCSSdkClient.Object;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using static SCSSdkClient.Object.SCSTelemetry;

namespace LuukOriginal.SCSPlugin
{
    public static class PluginInstance
    {
        public static SCSPlugin Plugin;
        public static SCSSdkTelemetry scsTelementry = new SCSSdkTelemetry();
    }
    public class SCSPlugin : MacroDeckPlugin
    {
        // Optional; If your plugin can be configured, set to "true". It'll make the "Configure" button appear in the package manager.
        public override bool CanConfigure => false;

        public bool ShouldUpdateVariables = true;

        public class VariableState
        {
            public string Name { get; set; }
            protected VariableType _type = VariableType.Bool;
            public VariableType Type { get { return _type; } set { _type = value; } }
            protected object _value = false;
            public object Value { get { return _value; } set { _value = value; } }
            protected bool _save = true;
            public bool Save { get { return _save; } set { _save = value; } }
        }

        public void SetVariable(VariableState variableState)
        {
            VariableManager.SetValue(string.Format("SCSPlugin_{0}", variableState.Name), variableState.Value, variableState.Type, this, variableState.Save);
        }

        public string GetVariable(string key)
        {
            var name = String.Format("SCSPlugin_{0}", key);
            //return VariableManager.Variables.Find(x => x.Name == name).Value;
            return Array.Find(VariableManager.Variables, x => x.Name == name)?.Value;
        }

        public string GetTimeFromSeconds(float seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }

        public void UpdateVariables(SCSTelemetry data, bool updated)
        {
            //if (!data.SdkActive) return;

            //LightValues
            string LightTag = "Lights_";

            SetVariable(new VariableState { Name = LightTag + "BeamLow_On", Value = data.TruckValues.CurrentValues.LightsValues.BeamLow, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = LightTag + "BeamHigh_On", Value = data.TruckValues.CurrentValues.LightsValues.BeamHigh, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = LightTag + "Beacon_On", Value = data.TruckValues.CurrentValues.LightsValues.Beacon, Type = VariableType.Bool, Save = false });

            SetVariable(new VariableState { Name = LightTag + "HazardLights_On", Value = data.TruckValues.CurrentValues.LightsValues.HazardWarningLights, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = LightTag + "LeftBlinker_On", Value = data.TruckValues.CurrentValues.LightsValues.BlinkerLeftOn, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = LightTag + "RightBlinker_On", Value = data.TruckValues.CurrentValues.LightsValues.BlinkerRightOn, Type = VariableType.Bool, Save = false });

            //Navigation
            string NavigationTag = "Navigation_";

            SetVariable(new VariableState { Name = NavigationTag + "NavigationTime", Value = GetTimeFromSeconds(data.NavigationValues.NavigationTime), Type = VariableType.String, Save = false });
            SetVariable(new VariableState { Name = NavigationTag + "NavigationDistance", Value = data.NavigationValues.NavigationDistance, Type = VariableType.Float, Save = false });

            SetVariable(new VariableState { Name = NavigationTag + "SpeedLimit_KMH", Value = (int)data.NavigationValues.SpeedLimit.Kph, Type = VariableType.Integer, Save = false });
            SetVariable(new VariableState { Name = NavigationTag + "SpeedLimit_MPH", Value = (int)data.NavigationValues.SpeedLimit.Mph, Type = VariableType.Integer, Save = false });

            //Dashboard
            string DashboardTag = "Dashboard_";
            SetVariable(new VariableState { Name = DashboardTag + "Wipers_On", Value = data.TruckValues.CurrentValues.DashboardValues.Wipers, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = DashboardTag + "ParkingBrake", Value = data.TruckValues.CurrentValues.MotorValues.BrakeValues.ParkingBrake, Type = VariableType.Bool, Save = false });

            SetVariable(new VariableState { Name = DashboardTag + "AirPressure", Value = data.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressure, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = DashboardTag + "AirPressure_Emergency", Value = data.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressureEmergency, Type = VariableType.Bool, Save = false });

            SetVariable(new VariableState { Name = DashboardTag + "Speed_KMH", Value = (int)data.TruckValues.CurrentValues.DashboardValues.Speed.Kph, Type = VariableType.Integer, Save = false });
            SetVariable(new VariableState { Name = DashboardTag + "Speed_MPH", Value = (int)data.TruckValues.CurrentValues.DashboardValues.Speed.Mph, Type = VariableType.Integer, Save = false });

            //Motor
            string MotorTag = "Motor_";
            SetVariable(new VariableState { Name = MotorTag + "EngineEnabled", Value = data.TruckValues.CurrentValues.EngineEnabled, Type = VariableType.Bool, Save = false });

            //Fuel
            string FuelTag = "Fuel_";
            SetVariable(new VariableState { Name = FuelTag + "FuelAmount", Value = Math.Round(data.TruckValues.CurrentValues.DashboardValues.FuelValue.Amount, 1), Type = VariableType.Float, Save = false });
            SetVariable(new VariableState { Name = FuelTag + "FuelRange", Value = Math.Round(data.TruckValues.CurrentValues.DashboardValues.FuelValue.Range, 1), Type = VariableType.Float, Save = false });
            SetVariable(new VariableState { Name = FuelTag + "FuelAverageConsumption", Value = Math.Round(data.TruckValues.CurrentValues.DashboardValues.FuelValue.AverageConsumption, 1), Type = VariableType.Float, Save = false });

            SetVariable(new VariableState { Name = FuelTag + "FuelWarning", Value = data.TruckValues.CurrentValues.DashboardValues.WarningValues.FuelW, Type = VariableType.Bool, Save = false });

            //Trailer
            string TrailerTag = "Trailer_";
            SetVariable(new VariableState { Name = TrailerTag + "Attached", Value = data.TrailerValues[0].Attached, Type = VariableType.Bool, Save = false });

            //Job
            string JobTag = "Job_";
            SetVariable(new VariableState { Name = JobTag + "CityDestination", Value = data.JobValues.CityDestination, Type = VariableType.String, Save = false });
            SetVariable(new VariableState { Name = JobTag + "CompanyDestination", Value = data.JobValues.CompanyDestination, Type = VariableType.String, Save = false });

            SetVariable(new VariableState { Name = JobTag + "CitySource", Value = data.JobValues.CitySource, Type = VariableType.String, Save = false });
            SetVariable(new VariableState { Name = JobTag + "CompanySource", Value = data.JobValues.CompanySource, Type = VariableType.String, Save = false });

            SetVariable(new VariableState { Name = JobTag + "Payout", Value = data.JobValues.Income, Type = VariableType.Integer, Save = false });
            SetVariable(new VariableState { Name = JobTag + "CargoName", Value = data.JobValues.CargoValues.Name, Type = VariableType.String, Save = false });
            SetVariable(new VariableState { Name = JobTag + "CargoLoaded", Value = data.JobValues.CargoLoaded, Type = VariableType.Bool, Save = false });
            SetVariable(new VariableState { Name = JobTag + "PlannedDistance_KM", Value = data.JobValues.PlannedDistanceKm, Type = VariableType.Integer, Save = false });

            SetVariable(new VariableState { Name = JobTag + "DeliveryTime", Value = data.JobValues.DeliveryTime.Date.ToString("dddd HH:mm"), Type = VariableType.String, Save = false });
            SetVariable(new VariableState { Name = JobTag + "RemainingDeliveryTime", Value = data.JobValues.RemainingDeliveryTime.Date.ToString("HH:mm:ss"), Type = VariableType.String, Save = false });
        }


        public SCSPlugin()
        {
            if (PluginInstance.Plugin == null)
            {
                PluginInstance.Plugin = this;
            }
        }



        // Gets called when the plugin is loaded
        public override void Enable()
        {
            MacroDeckLogger.Info(PluginInstance.Plugin, "SCSPlugin started...");
            PluginInstance.scsTelementry.Data += UpdateVariables;
        }

        // Optional; Gets called when the user clicks on the "Configure" button in the package manager; If CanConfigure is not set to true, you don't need to add this
        public override void OpenConfigurator()
        {
            return;
        }
    }
}