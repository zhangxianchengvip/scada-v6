echo 'return build Directory'
cd ../../../
echo 'build ScadaCommon'
dotnet build ScadaCommon/ScadaCommon.sln -c Release

echo 'build ScadaAgent'
dotnet build ScadaAgent/ScadaAgent/ScadaAgent.sln -c Release

echo 'build ScadaComm'
dotnet build ScadaComm/ScadaComm/ScadaComm.sln -c Release

echo 'build ScadaServer'
dotnet build ScadaServer/ScadaServer/ScadaServer.sln -c Release

echo 'build ScadaWeb'
dotnet build ScadaWeb/ScadaWeb/ScadaWeb.sln -c Release

echo 'build ScadaReport'
dotnet build ScadaReport/ScadaReport.sln -c Release

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