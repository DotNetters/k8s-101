// Load the http module to create an http server.
var http = require('http');
const { v4: uuidv4 } = require('uuid');
var fs = require('fs');

// Constants
const PORT = 8000;
const HOST = '127.0.0.1';

// Configure our HTTP server to respond with Hello World to all requests.
var server = http.createServer(function (request, response) {
  var filename = uuidv4();
  fs.writeFile('/app/requests/' + filename, 'Hello content!', function (err) {
    if (err) throw err;
    console.log('Saved!' + filename);
  });

  response.writeHead(200, {"Content-Type": "text/plain"});
  response.end("Hello " + filename + "\n");
});

// Listen on port 8000, IP defaults to 127.0.0.1
server.listen(PORT);

// Put a friendly message on the terminal
console.log(`Server running at http://${HOST}:${PORT}/`);
