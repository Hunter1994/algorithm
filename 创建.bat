set /p value=<./index.txt
set /a value=value+1;
md %value%
echo %value% > ./index.txt
echo %value%
cd %value%
dotnet new console
