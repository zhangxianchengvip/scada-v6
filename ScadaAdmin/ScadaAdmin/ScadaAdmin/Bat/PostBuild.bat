echo 'return Move Directory'
cd ../../../

REM OpenExtensions
setlocal enabledelayedexpansion

for /D %%d in (.\ScadaAdmin\OpenExtensions\*) do (

    set "dir_name=%%~nd"
    set "file_ex=dll"
    set "target_dll=!dir_name!.!file_ex!"
    
    set "subDir=%%d\bin\Release"
    
    rem 判断子目录是否存在
    if exist "!subDir!" (

        pushd "!subDir!"
        
        for /r %%i in (*.dll) do (
            if "%%~nxi" == "!target_dll!" (

                REM 构建目标复制路径，注意使用正斜杠（/）作为路径分隔符
                set "target_dug_path=..\..\..\..\ScadaAdmin\ScadaAdmin\bin\Debug\net8.0-windows\Lib\"
                set "target_pub_path=..\..\..\..\ScadaAdmin\ScadaAdmin\bin\Release\net8.0-windows\publish\Lib\"
                REM 确保目标路径存在
                if not exist "!target_dug_path!" mkdir "!target_path!"
                if not exist "!target_pub_path!" mkdir "!target_pub_path!"
                REM 复制文件
                copy "%%~fi" "!target_dug_path!"
                copy "%%~fi" "!target_pub_path!"
            )
        )
        popd
    )
)

endlocal


REM OpenModules

setlocal enabledelayedexpansion

for /D %%d in (.\ScadaServer\OpenModules\*) do (

    set "dir_name=%%~nxd"
    set "file_ex=dll"
    set "target_dll=!dir_name!.!file_ex!"

    set "subDir=%%d\bin\Release"
    
    rem 判断子目录是否存在
    if exist "!subDir!" (

        pushd "!subDir!"
        

        for /r %%i in (*.dll) do (
            if "%%~nxi" == "!target_dll!" (
 
                REM 构建目标复制路径，注意使用正斜杠（/）作为路径分隔符
                set "target_dug_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Debug\net8.0-windows\Lib\"
                set "target_pub_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Release\net8.0-windows\publish\Lib\"
                REM 确保目标路径存在
                if not exist "!target_dug_path!" mkdir "!target_path!"
                if not exist "!target_pub_path!" mkdir "!target_pub_path!"
                REM 复制文件
                copy "%%~fi" "!target_dug_path!"
                copy "%%~fi" "!target_pub_path!"
            )
        )
        popd
    )
)

endlocal


REM OpenDrivers

setlocal enabledelayedexpansion

for /D %%d in (.\ScadaComm\OpenDrivers\*) do (

    set "dir_name=%%~nxd"
    set "file_ex=dll"
    set "target_dll=!dir_name!.!file_ex!"
    
    set "subDir=%%d\bin\Release"
    
    rem 判断子目录是否存在
    if exist "!subDir!" (

        pushd "!subDir!"
        

    for /r %%i in (*.dll) do (
         if "%%~nxi" == "!target_dll!" (

            REM 构建目标复制路径，注意使用正斜杠（/）作为路径分隔符
            set "target_dug_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Debug\net8.0-windows\Lib\"
            set "target_pub_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Release\net8.0-windows\publish\Lib\"
            REM 确保目标路径存在
            if not exist "!target_dug_path!" mkdir "!target_path!"
            if not exist "!target_pub_path!" mkdir "!target_pub_path!"
            REM 复制文件
            copy "%%~fi" "!target_dug_path!"
            copy "%%~fi" "!target_pub_path!"
        )
    )
    popd
    )
)

endlocal

REM OpenDrivers2

setlocal enabledelayedexpansion

for /D %%d in (.\ScadaComm\OpenDrivers2\*) do (

    set "dir_name=%%~nxd"
    set "file_ex=dll"
    set "target_dll=!dir_name!.!file_ex!"
    
    set "subDir=%%d\bin\Release"
    
    rem 判断子目录是否存在
    if exist "!subDir!" (

        pushd "!subDir!"
        

    for /r %%i in (*.dll) do (
         if "%%~nxi" == "!target_dll!" (

            REM 构建目标复制路径，注意使用正斜杠（/）作为路径分隔符
            set "target_dug_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Debug\net8.0-windows\Lib\"
            set "target_pub_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Release\net8.0-windows\publish\Lib\"
            REM 确保目标路径存在
            if not exist "!target_dug_path!" mkdir "!target_path!"
            if not exist "!target_pub_path!" mkdir "!target_pub_path!"
            REM 复制文件
            copy "%%~fi" "!target_dug_path!"
            copy "%%~fi" "!target_pub_path!"
        )
    )
    popd
    )
)

endlocal

REM OpenPlugins

setlocal enabledelayedexpansion

for /D %%d in (.\ScadaWeb\OpenPlugins\*) do (

    set "dir_name=%%~nxd"
    set "file_ex=dll"
    set "target_dll=!dir_name!.!file_ex!"
    
    set "subDir=%%d\bin\Release"
    
    rem 判断子目录是否存在
    if exist "!subDir!" (

        pushd "!subDir!"
        
        for /r %%i in (*.dll) do (
            if "%%~nxi" == "!target_dll!" (

                REM 构建目标复制路径，注意使用正斜杠（/）作为路径分隔符
                set "target_dug_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Debug\net8.0-windows\Lib\"
                set "target_pub_path=..\..\..\..\..\ScadaAdmin\ScadaAdmin\ScadaAdmin\bin\Release\net8.0-windows\publish\Lib\"
                REM 确保目标路径存在
                if not exist "!target_dug_path!" mkdir "!target_path!"
                if not exist "!target_pub_path!" mkdir "!target_pub_path!"
                REM 复制文件
                copy "%%~fi" "!target_dug_path!"
                copy "%%~fi" "!target_pub_path!"
            )
        )
        popd
    )
)

endlocal