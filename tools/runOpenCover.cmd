rmdir CoverageReport /S /Q

OpenCover\tools\OpenCover.Console.exe -skipautoprops -register:user -target:NUnitConsole\nunit3-console.exe -register:user "-targetargs:..\src\Giacomelli.JumpStart.UnitTests\bin\Debug\Giacomelli.JumpStart.UnitTests.dll" -filter:"+[Giacomelli.JumpStart]*" -output:coverage.xml

ReportGenerator\ReportGenerator.exe -reports:coverage.xml -targetdir:CoverageReport

start CoverageReport\index.htm
