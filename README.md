Rrs.Data.SqlServer
==================
A sql server implementation of IDbConnectionFactory from [Rrs.Data](https://github.com/rrs/Data) and a factory class

Usage
-----

```
var connectionString = "connectionString";
var db = SqlServerDelegatorFactory.Create(connectionString);
```