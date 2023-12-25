@echo off

set lib="Ans.Net8.Common"

set /p host="Enter host path for '%lib%' library: "
if "%host%"=="" goto END
echo.

echo Stopping the site application.
rename %host%\_app_offline.htm app_offline.htm
echo.
pause

copy %host%\%lib%.dll %host%\%lib%.~dll
copy %host%\%lib%.pdb %host%\%lib%.~pdb
copy %lib%.dll %host%
copy %lib%.pdb %host%

echo Launching the site application.
rename %host%\app_offline.htm _app_offline.htm
echo.

echo [END] Update completed.
echo.

:END

pause

