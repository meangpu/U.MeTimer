@echo off
setlocal EnableDelayedExpansion
rem Get the directory of the current script
set "scriptDir=%~dp0"
set "filePath=%scriptDir%package.json"

rem Read current version
for /f "tokens=1,* delims=:" %%a in ('findstr /C:"\"version\":" "%filePath%"') do (
    set "version=%%b"
)
set "version=!version:~2,-2!"

rem Increment version
for /f "tokens=1,2,3 delims=." %%a in ("!version!") do (
    set "major=%%a"
    set "minor=%%b"
    set /a "patch=%%c+1"
)
set "newVersion=!major!.!minor!.!patch!"

rem Update file
set "versionUpdated="
(for /f "usebackq delims=" %%a in ("%filePath%") do (
    set "line=%%a"
    if not defined versionUpdated (
        echo !line! | findstr /C:"\"version\":" >nul
        if !errorlevel! equ 0 (
            echo   "version": "!newVersion!",
            set "versionUpdated=1"
        ) else (
            echo !line!
        )
    ) else (
        echo !line!
    )
)) > "%scriptDir%temp.json"
move /Y "%scriptDir%temp.json" "%filePath%"
echo Version updated to !newVersion!

rem Git operations ===================================
cd %scriptDir%
git add *
git commit -m "Bump version to !newVersion!"
git push

echo Version updated and changes pushed to git repository.
endlocal