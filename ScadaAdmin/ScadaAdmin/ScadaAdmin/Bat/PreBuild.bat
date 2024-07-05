echo 'return build Directory'
cd ../../../
rem echo 'build ScadaCommon'
rem dotnet build ScadaCommon/ScadaCommon.sln -c Release

rem echo 'build ScadaAgent'
rem dotnet build ScadaAgent/ScadaAgent/ScadaAgent.sln -c Release

rem echo 'build ScadaComm'
rem dotnet build ScadaComm/ScadaComm/ScadaComm.sln -c Release

rem echo 'build ScadaServer'
rem dotnet build ScadaServer/ScadaServer/ScadaServer.sln -c Release

rem echo 'build ScadaWeb'
rem dotnet build ScadaWeb/ScadaWeb/ScadaWeb.sln -c Release

rem echo 'build ScadaReport'
rem dotnet build ScadaReport/ScadaReport.sln -c Release

echo 'build OpenDrivers'
dotnet build ScadaComm/OpenDrivers/OpenDrivers.sln -c Release

echo 'build OpenDrivers2'
dotnet build ScadaComm/OpenDrivers2/OpenDrivers2.sln -c Release

echo 'build OpenModules'
dotnet build ScadaServer/OpenModules/OpenModules.sln -c Release

echo 'build OpenPlugins'
dotnet build ScadaWeb/OpenPlugins/OpenPlugins.sln -c Release

echo 'build OpenExtensions'
dotnet build ScadaAdmin/OpenExtensions/OpenExtensions.sln -c Release