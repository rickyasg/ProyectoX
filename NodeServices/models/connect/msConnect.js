const sql = require('mssql')
const strings = require('./strings')
module.exports = {
    getQuery: function (sqlInput) {
        return new Promise(function (resolve, reject) {
            sql.connect(strings.sqlServer).then(function () {
                var request = new sql.Request();
                request.query(sqlInput, (err, result) => {
                    sql.close();
                    if (err) {
                        reject(err);
                    } else {                        
                        resolve(result.recordset);
                    }
                })
            })
        })
    },
    executeProcedure: function (procedureName, parameters) {
        return new Promise(function (resolve, reject) {
            sql.connect(strings.sqlServer).then(function () {
                var request = new sql.Request();
                parameters.forEach(tipo => {
                    request.input(tipo.name, tipo.type, tipo.value);
                });
                request.execute(procedureName, (err, result) => {
                    sql.close();
                    if (err) {
                        reject(err);
                    } else {
                        resolve(result.recordset);
                    }
                });
            })
        })
    }

};