ipconfig | find "IPv4 Address" >> "\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
echo %computername%, %date%, %time%: "Starting Install". >> "\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"

mkdir c:\progra~1\HTC\Logs
echo %computername%, %date% %time%: Creating local FOP directory. >> "\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
mkdir c:\progra~1\HTC\fop

echo %computername%, %date% %time%: Copying FOP files from network. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
echo D | xcopy "\\iomega-nas\public1\IT Department\Pinnacle\fop" c:\progra~1\HTC\fop /y /e
echo %computername%, %date% %time%: Success Copying fop files to local machine. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"

echo %computername%, %date% %time%: Installing MS C++ Library. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
"\\iomega-nas\public1\IT Department\Pinnacle\Client_Setup\vcredist_x86.exe" /q
echo %computername%, %date% %time%: Success C++ Library. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"

echo %computername%, %date% %time%: Installing Java JRE. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
"\\iomega-nas\public1\IT Department\Pinnacle\Client_Setup\jre-7u7-windows-i586.exe" /s
echo %computername%, %date% %time%: Success Java JRE. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"


echo %computername%, %date% %time%: Installing .Net Client. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
  "\\iomega-nas\public1\IT Department\Pinnacle\Client_Setup\dotNetFx40_Client_setup.exe" /q /norestart
echo %computername%, %date% %time%: Success .Net Client. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
echo %computername%, %date% %time%: Uninstalling Pinnacle DB Client, if exists. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
msiexec /x "\\iomega-nas\Public1\IT Department\Pinnacle\Client_Setup\PinnacleSetup.msi" /qn  /l*ie "\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall_MSI.Log"
echo %computername%, %date% %time%: Installing Pinnacle DB Client. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"
msiexec /i "\\iomega-nas\public1\IT Department\Pinnacle\Client_Setup\PinnacleSetup.msi" /qn  /l*ie "\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall_MSI.Log" ALLUSERS=1
echo %computername%, %date% %time%: Success Pinnacle DB Client. >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"


echo %computername%, %date% %time%: Success INSTALL COMPLETE!!!! >>"\\iomega-nas\Public1\IT Department\Pinnacle\Logs\ClientInstall.Log"