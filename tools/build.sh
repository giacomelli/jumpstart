mkdir ../build

cd ../src/Giacomelli.JumpStart/bin/Release

/Library/Frameworks/Mono.framework/Versions/4.4.2/bin/mono ../../../../tools/ILRepack.exe /target:exe /out:../../../../build/jumpstart.exe  jumpstart.exe /wildcards *.*

cd ../../../../tools
