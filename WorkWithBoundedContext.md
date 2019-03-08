##GENERAL data Context
##### to creaate or add new migration use next command:
    Add-Migration `Init_EstelContext` -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations
##### to update database with migration use next command:
    update-database                   -Context EstelContext  -Project EstelApi.Domain.DataAccessLayer.Context


##EventSoursing data Context
##### to creaate or add new migration use next command:
    Add-Migration `Init_EventStoreSQLContext` -Context EventStoreSQLContext -Project EstelApi.Domain.DataAccessLayer.Context -OutputDir Migrations\EventStore
##### to update database with migration use next command:
    update-database                           -Context EventStoreSQLContext -Project EstelApi.Domain.DataAccessLayer.Context



##Identity data Context
##### to creaate or add new migration use next command:
    Add-Migration Init_IdentityEstelContext -Context IdentityEstelContext -OutputDir Migrations -Project EstelApi.CrossCutting.Identity
##### to update database with migration use next command:
    update-database							-Context IdentityEstelContext                       -Project EstelApi.CrossCutting.Identity