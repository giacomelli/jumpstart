echo Building jumpstart.exe...

mkdir C:\projects\jumpstart\build
cd C:\projects\jumpstart\src\Giacomelli.JumpStart\bin\Release

echo Calling ILRepack...
C:\projects\jumpstart\tools\ILRepack.exe /target:library /out:C:\projects\jumpstart\build\jumpstart.exe /wildcards jumpstart.exe /wildcards *.dll
echo ILRepack finished.

cd C:\projects\jumpstart

echo done!
