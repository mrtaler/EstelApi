##GENERAL data Context
##### to creaate or add new migration use next command:
    Add-Migration Init_EstelContext -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations
##### to update database with migration use next command:
    update-database                   -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context
##### To delete last non commited migration
    Remove-Migration -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context
##### to Revert database:
    Update-database InitialCOntext  -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context



##EventSoursing data Context
##### to creaate or add new migration use next command:
    Add-Migration Init_EventStoreSQLContext -Context EventStoreSQLContext -Project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations\EventStore
##### to update database with migration use next command:
    update-database                           -Context EventStoreSQLContext -Project EstelApi.Domain.DataAccessLayer.Context



##Identity data Context
##### to creaate or add new migration use next command:
    Add-Migration Init_IdentityEstelContext -Context IdentityEstelContext -OutputDir Migrations -Project EstelApi.CrossCutting.Identity
##### to update database with migration use next command:
    update-database							-Context IdentityEstelContext                       -Project EstelApi.CrossCutting.Identity


    https://sonarcloud.io/organizations/mrtaler-github/projects

 C:\Users\siarhei_linkevich\.dotnet\tools\dotnet-sonarscanner.exe begin /k:"mrtaler_EstelApi" /o:"mrtaler-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="ce6b0541cf3998c5da216158c5b686d2f2b3f1a2"
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64\MsBuild.exe" /t:Rebuild
C:\Users\siarhei_linkevich\.dotnet\tools\dotnet-sonarscanner.exe end /d:sonar.login="ce6b0541cf3998c5da216158c5b686d2f2b3f1a2"