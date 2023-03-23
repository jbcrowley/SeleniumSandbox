@echo off
rem   just kills stray local chromedriver.exe, geckodriver.exe, and IE instances.
rem   useful if you are trying to clean your project, and your ide is complaining.

taskkill /im chromedriver.exe /f 2> nul
taskkill /im IEDriverServer.exe /f 2> nul
taskkill /im geckodriver.exe /f 2> nul

exit /b 0