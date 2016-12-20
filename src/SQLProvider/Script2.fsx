
(*
#r "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.0/System.Transactions.dll"
#r "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.0/System.Runtime.Serialization.dll"

#load "Operators.fs"
#r "C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.0/System.Configuration.dll"
#load "Utils.fs"
#load "SqlSchema.fs"
#load "SqlRuntime.Common.fs"
//#load "SqlRuntime.Patterns.fs"
#load "DataTable.fs"
#load "Providers.Firebird.fs"

open FSharp.Data.Sql
open FSharp.Data.Sql.Providers

let [<Literal>] resolutionPath = "D:/Gibran/Projetos/FirebirdNetProvider141216/src/FirebirdSql.Data.FirebirdClient/bin/Debug/NET40" 
let [<Literal>] connectionString = @"character set=NONE;data source=localhost;initial catalog=d:\Tisul\Gestao\Dados\ROMENA.FDB;user id=SYSDBA;password=masterkey;dialect=1"


Firebird.resolutionPath <- resolutionPath

let connection = Firebird.createConnection connectionString

Common.Sql.connect connection Firebird.createTypeMappings

Firebird.typeMappings

let t = 
    Common.Sql.connect connection (Firebird.getSchema "Procedures" [||])
    |> DataTable.headers
    |> DataTable.map (fun r -> r.["PROCEDURE_NAME"], r.["IS_SYSTEM_PROCEDURE"])
//|> DataTable.printDataTable

*)
