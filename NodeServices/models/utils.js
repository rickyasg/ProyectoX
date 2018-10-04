// const sql = require ('mssql')
var Connection = require('tedious').Connection;  
// var Request = require('tedious').Request;
// var TYPES = require('tedious').TYPES;
module.exports = {
    suma: function (a, b) {
      var config ={
        userName:'sa',
        password:'Desarrollo_123',
        server:'localhost',
        // database:'erpDeporteSucre',
        options: {encrypt: true, database: 'erpDeporteSucre'}  
      }
     
        try{
        /////////////////////
        var connection = new Connection(config);  
        connection.on('connect', function(err) {  
            // If no error, then good to proceed.  
            console.log("Connected");  
            executeStatement();  
        });  
    
        var Request = require('tedious').Request;  
        var TYPES = require('tedious').TYPES;  
    
        function executeStatement() {  
            request = new Request("SELECT TOP 1 *  FROM  dbo.cron_futbol", function(err) {  
            if (err) {  
                console.log(err);}  
            });  
            var result = "";  
            request.on('row', function(columns) {  
                columns.forEach(function(column) {  
                  if (column.value === null) {  
                    console.log('NULL');  
                  } else {  
                    result+= column.value + " ";  
                  }  
                });  
                console.log(result);  
                result ="";  
            });  
    
            request.on('done', function(rowCount, more) {  
            console.log(rowCount + ' rows returned');  
            });  
            connection.execSql(request);  
        /////////////////
      
      }
    }
      catch(err)
      {
        console.log (err);
      }
      return a + b;
    }
  }
 