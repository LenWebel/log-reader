Targets net5.0

`./docker` folder contains a docker-compose file that stands up an `elk stack` using `docker` and `docker-compose`.
`./data` folder contains the log file provided my Azenix
`./mappers` folder contains a rudimentary mapper class that maps log reader results to an object.
`./models` folder contains a structure to map the log file to.
`.services` folder contains the services required to read the data file, and query the data for the specific tasks outlined in the requirements Doc.

