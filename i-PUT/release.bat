rmdir /Q /S ..\Release
mkdir ..\Release
mkdir ..\Release\i-PUT

xcopy /E /EXCLUDE:exclude.txt . ..\Release\i-PUT