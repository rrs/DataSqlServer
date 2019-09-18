Rrs.Data.SqlServer
==================
A sql server implementation of IDbConnectionFactory from [Rrs.Data](https://github.com/rrs/Data) and a factory class

Usage
-----

## Connection String

```
var connectionString = "connectionString";
var db = SqlServerDelegatorFactory.Create(connectionString);
```

## Sql Auth

```
var connectionProperties = new SqlServerConnectionProperties(server, database, username, password);
var db = SqlServerDelegatorFactory.Create(connectionProperties);
```

## Windows Auth

```
var connectionProperties = new SqlServerConnectionProperties(server, database);
var db = SqlServerDelegatorFactory.Create(connectionProperties);
```
