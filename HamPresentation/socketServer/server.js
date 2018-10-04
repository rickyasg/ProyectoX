'use strict';

let app = require('express')();
let http = require('http').Server(app);
let io = require('socket.io')(http);

io.on('connection', (socket) => {
  console.log(socket.id);
  
  socket.on('disconnect', function(){
    console.log('USER DISCONNECTED');
  });

  socket.on('on-clasificatorio', () => {    
    socket.broadcast.emit('handle-clasificatorio');
  });
  socket.on('on-changeClasificatorio', (data) => {    
    socket.broadcast.emit('handle-changeClasificatorio', {data : data});
  });
});
http.listen(8080, () => {
  console.log('started on port 8080');             
});
