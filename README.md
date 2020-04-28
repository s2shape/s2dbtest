# Database tester
This projects tests connection strings by attempting to open a SQL server database given a connection string.

# Building
```
dotnet restore
dotnet publish --output ./release
cd release
```

# Usage
```
dotnet S2DbTester.dll 'Server=10.10.10.22;Database=SupplyChain;MultipleActiveResultSets=True;App=s2api;persist security info=True;packet size=4096;user id=blackswanro;password=ThePassword'
Starting Ado.NET connection test...
Ado.NET connection test passed
Starting S2 connection test...
S2 connection test passed
All tests complete.
```
