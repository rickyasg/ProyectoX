var express = require('express');
var tools = require('../models/connect/msConnect');
const sql = require('mssql')
var router = express.Router();


/* GET users listing. */
router.get('/lista/:id', function (req, res) {
  tools.getQuery('select * from Usuarios Where UsuarioId = ' + req.params.id).then((data) => {
    res.send(data);
  });
});
router.post('/procedure', function (req, res) {
  var parameters = new Array();
  parameters.push({ name: 'ObjetivoId', type: sql.Int, value: req.body.objetivoId });
  tools.executeProcedure('pplagetActividades', parameters).then((data) => {
    res.send(data);
  });
});

module.exports = router;
