# MapReduceWordCounterAWS
A service-oriented web application & the SOAP services that collectively count the number of words in a text file via MapReduce. It uses the Task-Based Asynchronous Pattern. The SOAP services & some client methods use async, await, & Task. The web services are configured such that a new instance is created per call. 
        
Uses PostedFile & InputStream to read the file. The file is not stored. The file contents are partitioned & handled by tasks. It mimics the Hadoop process by distributing the data & the processing over a network.
        
This was created using Visual Studio 2017.

To run...

Download the MapReduceWordCounterAWS repository

Double click the MapReduceWordCounter.sln file

Under the CombineService project, right click the Service1.svc file & select 'View in Browser'

Under the MapService project, right click the Service1.svc file & select 'View in Browser'

Under the ReduceService project, right click the Service1.svc file & select 'View in Browser'

Right click the MapReduceWordCounter project & select 'Set as StartUp Project'

Select the 'Debug' tab & then select 'Start Without Debugging'
