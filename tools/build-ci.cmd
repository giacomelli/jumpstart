echo Building jumpstart.exe...

mkdir C:\projects\Giacomelli-Jumpstart\build
cd C:\projects\Giacomelli-Jumpstart\src\Giacomelli-Jumpstart\bin\Release

echo Calling ILRepack...
C:\projects\Giacomelli-Jumpstart\tools\ILRepack.exe /target:library /out:C:\projects\Giacomelli-Jumpstart\build\jumpstart.exe /wildcards jumpstart.exe /wildcards *.*
echo ILRepack finished.

cd C:\projects\Giacomelli-Jumpstart

echo done!
